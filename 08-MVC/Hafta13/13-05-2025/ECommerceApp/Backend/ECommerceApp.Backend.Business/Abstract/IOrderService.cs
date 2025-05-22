using System;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface IOrderService
{
    Task<ResponseDTO<OrderDTO>> OrderNowAsync(OrderNowDTO orderNowDto);
    Task<ResponseDTO<NoContentDTO>> ChangeOrderStatusAsync(ChangeOrderStatusDTO changeOrderStatusDto);
    Task<ResponseDTO<OrderDTO>> GetAsync(int id);
    Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllAsync(GetAllOrderDTO getAllOrderDTO);
    Task<ResponseDTO<NoContentDTO>> CancelOrderAsync(int id);
}
