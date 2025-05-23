using System;
using AutoMapper;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Data.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.CartDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Backend.Business.Concrete;

public class CartService : ICartService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Cart> _cartRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<CartItem> _cartItemRepository;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Cart> cartRepository, IGenericRepository<Product> productRepository, IGenericRepository<CartItem> cartItemRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<ResponseDTO<CartItemDTO>> AddToCartAsync(AddToCartDTO addToCartDTO)
    {
        try
        {
            var isExists = await _productRepository.ExistsAsync(x => x.Id == addToCartDTO.ProductId);
            if (!isExists)
            {
                return ResponseDTO<CartItemDTO>.Fail("Ürün bulunamadığı için sepete eklenemedi!", StatusCodes.Status404NotFound);
            }
            var cart = await _cartRepository.GetAsync(
                predicate: x => x.AppUserId == addToCartDTO.AppUserId,
                includes: query => query.Include(x => x.CartItems).ThenInclude(x => x.Product)
            );
            if (cart is null)
            {
                return ResponseDTO<CartItemDTO>.Fail("Kullanıcıya ait sepet bilgileri bulunamadı!", StatusCodes.Status404NotFound);
            }
            var existsCartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == addToCartDTO.ProductId);
            if (existsCartItem is not null)//eğer ürün sepette varsa
            {
                existsCartItem.Quantity += addToCartDTO.Quantity;
                _cartItemRepository.Update(existsCartItem);
                var updateResult = await _unitOfWork.SaveAsync();
                if (updateResult == 0)
                {
                    return ResponseDTO<CartItemDTO>.Fail("Sunucuda bir sorun oluştuğu için ürün sepete eklenemedi",StatusCodes.Status500InternalServerError);
                }
                var existsCartItemDTO = _mapper.Map<CartItemDTO>(existsCartItem);
                return ResponseDTO<CartItemDTO>.Success(existsCartItemDTO,"Sepetteki ürün adedi güncellendi",StatusCodes.Status200OK);
            }
            var cartItem = new CartItem
            {
                CartId =cart.Id,
                ProductId = addToCartDTO.ProductId,
                Quantity = addToCartDTO.Quantity
            };
            cart.CartItems.Add(cartItem);
            _cartRepository.Update(cart);
            var createResult = await _unitOfWork.SaveAsync();
            if (createResult == 0)
            {
                return ResponseDTO<CartItemDTO>.Fail("Sunucuda bir sorun oluştuğu için ürün sepete eklenemedi", StatusCodes.Status500InternalServerError);
            }
            var cartItemDTO = _mapper.Map<CartItemDTO>(cartItem);
            return ResponseDTO<CartItemDTO>.Success(cartItemDTO,"Ürün Sepete eklendi",StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            return ResponseDTO<CartItemDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> ChangeQuantityAsync(ChangeQuantityDTO changeQuantityDTO)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetAsync(predicate: x=>x.Id == changeQuantityDTO.CartItemId);
            if(cartItem is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Ürün Sepette bulunamadığı için adedi güncellenemedi",StatusCodes.Status404NotFound);
            }
            cartItem.Quantity = changeQuantityDTO.Quantity;
            _cartItemRepository.Update(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sunucuda bir sorun oluştuğu için aded güncellenemedi", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("Adet güncellendi",StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> ClearCartAsync(string appUserId)
    {
        try
        {
            var cart = await _cartRepository.GetAsync(
                predicate: x=>x.AppUserId == appUserId,
                includes: query => query.Include(x=>x.CartItems)
            );
            if(cart is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sepet Bulunamadı!",StatusCodes.Status404NotFound);
            }
            cart.CartItems.Clear();
            _cartRepository.Update(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sunucuda bir sorun oluştuğu için aded güncellenemedi", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("Sepet Temizlendi",StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<CartDTO>> CreateCartAsync(CartCreateDTO cartCreateDTO)
    {
        try
        {
            var cart = await _cartRepository.GetAsync(x=>x.AppUserId == cartCreateDTO.AppUserId);
            if(cart is not null)
            {
                return ResponseDTO<CartDTO>.Fail("Bu kullanıcıya ait sepet zaten mevcut",StatusCodes.Status400BadRequest);
            }
            cart = new Cart(cartCreateDTO.AppUserId);
            await _cartRepository.AddAsync(cart);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return ResponseDTO<CartDTO>.Fail("Sunucuda bir sorun oluştuğu için aded güncellenemedi", StatusCodes.Status500InternalServerError);
            }
            var cartDTO = _mapper.Map<CartDTO>(cart);
            return  ResponseDTO<CartDTO>.Success(cartDTO, "İşlem Başarılı",StatusCodes.Status201Created);

        }
        catch (Exception ex)
        {
            return ResponseDTO<CartDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<CartDTO>> GetCartAsync(string appUserId)
    {
        try
        {
            var cart = await _cartRepository.GetAsync(
                predicate: x => x.AppUserId == appUserId,
                includes: query =>query.Include(x=>x.CartItems).ThenInclude(x=>x.Product)
            );
            if (cart is null)
            {
                return ResponseDTO<CartDTO>.Fail("Bu kullanıcıya ait sepet Bulunamadı", StatusCodes.Status404NotFound);
            }
            var cartDTO = _mapper.Map<CartDTO>(cart);
            return ResponseDTO<CartDTO>.Success(cartDTO, "İşlem Başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<CartDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<ResponseDTO<NoContentDTO>> RemoveFromCartAsync(int cartItemId)
    {
        try
        {
            var cartItem = await _cartItemRepository.GetAsync(cartItemId);
            if(cartItem is null)
            {
                return ResponseDTO<NoContentDTO>.Fail("İlgili ürün sepette bulunamadığı için kaldırılamadı",StatusCodes.Status404NotFound);
            }
            _cartItemRepository.Delete(cartItem);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return ResponseDTO<NoContentDTO>.Fail("Sunucuda bir sorun oluştuğu için aded güncellenemedi", StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContentDTO>.Success("Ürün Sepetten Kaldırıldı", StatusCodes.Status200OK);


        }
        catch (Exception ex)
        {
            return ResponseDTO<NoContentDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}
