using System;
using System.Linq.Expressions;
using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Backend.Business.Concrete;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICartService _cartService;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<Product> _productRepository;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ICartService cartService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cartService = cartService;
        _orderRepository = _unitOfWork.GetRepository<Order>();
        _productRepository = _unitOfWork.GetRepository<Product>();
    }
    public async Task<ResponseDTO<NoContentDTO>> CancelOrderAsync(int id)
    {
        try
        {
            var order = await _orderRepository.GetAsync(id);
            if (order is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("İlgili sipariş bulunamadığı için iptal edilemedi!", StatusCodes.Status404NotFound);
            }
            order.IsDeleted = true;
            order.DeletedAt = DateTime.UtcNow;
            _orderRepository.Update(order);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> ChangeOrderStatusAsync(ChangeOrderStatusDTO changeOrderStatusDto)
    {
        try
        {
            var order = await _orderRepository.GetAsync(changeOrderStatusDto.OrderId);
            if (order is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("İlgili sipariş bulunamadığı için sipariş durumu güncellenemedi!", StatusCodes.Status404NotFound);
            }
            order.OrderStatus = changeOrderStatusDto.OrderStatus;
            order.UpdatedAt = DateTime.UtcNow;
            _orderRepository.Update(order);
            var result = await _unitOfWork.SaveAsync();
            if (result != 1)
            {
                return ResponseDTO<NoContentDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllAsync(GetAllOrderDTO getAllOrderDTO)
    {
        try
        {
            bool includeDeleted = true;
            Expression<Func<Order, bool>> myPredicate = x => true;
            if (!string.IsNullOrEmpty(getAllOrderDTO.AppUserId))
            {
                myPredicate = myPredicate.And(x => x.AppUserId == getAllOrderDTO.AppUserId);
                if (getAllOrderDTO.IsDeleted == false) includeDeleted = false;
            }
            if (getAllOrderDTO.OrderStatus.HasValue)
            {
                myPredicate = myPredicate.And(x => x.OrderStatus == getAllOrderDTO.OrderStatus);
                if (getAllOrderDTO.IsDeleted == false) includeDeleted = false;
            }
            if (getAllOrderDTO.StartDate.HasValue && getAllOrderDTO.EndDate.HasValue)
            {
                myPredicate = myPredicate.And(x => x.CreatedAt >= getAllOrderDTO.StartDate && x.CreatedAt <= getAllOrderDTO.EndDate);
                if (getAllOrderDTO.IsDeleted == false) includeDeleted = false;
            }
            if (getAllOrderDTO.IsDeleted.HasValue)
            {
                myPredicate = myPredicate.And(x => x.IsDeleted == getAllOrderDTO.IsDeleted);
                if (getAllOrderDTO.IsDeleted == false) includeDeleted = false;
            }
            var orders = await _orderRepository.GetAllAsync(
                predicate: myPredicate,
                includes: query => query
                        .Include(x => x.AppUser)
                        .Include(x => x.OrderItems).ThenInclude(y => y.Product),
                includeDeleted: includeDeleted
            );

            if (orders is null || !orders.Any())
            {
                return ResponseDTO<IEnumerable<OrderDTO>>.Fail("Herhangi bir sipariş bilgisi bulunamamıştır!", StatusCodes.Status404NotFound);
            }
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return ResponseDTO<IEnumerable<OrderDTO>>.Success(orderDTOs, "İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<IEnumerable<OrderDTO>>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<OrderDTO>> GetAsync(int id)
    {
        try
        {
            var order = await _orderRepository.GetAsync(
                predicate: x => x.Id == id,
                includes: query => query
                        .Include(x => x.AppUser)
                        .Include(x => x.OrderItems).ThenInclude(y => y.Product)
            );
            if (order is null)
            {
                return ResponseDTO<OrderDTO>.Fail("İlgili sipariş bulunamadı", StatusCodes.Status404NotFound);
            }
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO, "İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<OrderDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<OrderDTO>> OrderNowAsync(OrderNowDTO orderNowDto)
    {
        try
        {
            foreach (var orderItem in orderNowDto.OrderItems)
            {
                var isExistsProduct = await _productRepository.ExistsAsync(x => x.Id == orderItem.ProductId);
                if (!isExistsProduct)
                {
                    return ResponseDTO<OrderDTO>.Fail($"{orderItem.ProductId} id'li ürün bulunamadığı için sipariş işlemi tamamlanamadı!", StatusCodes.Status404NotFound);
                }
            }
            var order = _mapper.Map<Order>(orderNowDto);
            await _orderRepository.AddAsync(order);
            var result = await _unitOfWork.SaveAsync();
            if (result < 1)
            {
                return ResponseDTO<OrderDTO>.Fail("Beklenmedik bir sorun oluştu!", StatusCodes.Status500InternalServerError);
            }
            await _cartService.ClearCartAsync(orderNowDto.AppUserId!);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return ResponseDTO<OrderDTO>.Success(orderDTO, "İşlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<OrderDTO>.Fail($"BEKLENMEDİK HATA: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}
