using ECommerceApp.Backend.API.ControllerBases;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.Controllers
{
    [Route("orders")]
    [ApiController]
    [Authorize]
    public class OrderController : CustomControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> OrderNow(OrderNowDTO orderNowDto)
        {
            orderNowDto.AppUserId = GetUserId();
            var response = await _orderService.OrderNowAsync(orderNowDto);
            return CreateResult(response);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var response = await _orderService.GetAsync(orderId);
            return CreateResult(response);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] OrderStatus? orderStatus, [FromQuery] string? appUserId, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] bool? isDeleted)
        {
            var filter = new GetAllOrderDTO(orderStatus, appUserId, startDate, endDate, isDeleted);
            var response = await _orderService.GetAllAsync(filter);
            return CreateResult(response);
        }

        [HttpGet("my-orders")]
        public async Task<IActionResult> GetAllMyOrders([FromQuery] OrderStatus? orderStatus, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var filter = new GetAllOrderDTO(orderStatus, GetUserId(), startDate, endDate);
            var response = await _orderService.GetAllAsync(filter);
            return CreateResult(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{orderId}")]   //    /orders/5?orderStatus=3
        public async Task<IActionResult> ChangeOrdersStatus(int orderId, [FromQuery] OrderStatus orderStatus)
        {
            var changeOrdersStatusDTO = new ChangeOrderStatusDTO(orderId, orderStatus);
            var response = await _orderService.ChangeOrderStatusAsync(changeOrdersStatusDTO);
            return CreateResult(response);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("{orderId}/cancel")]    //  /orders/5/cancel
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var response = await _orderService.CancelOrderAsync(orderId);
            return CreateResult(response);
        }

    }
}
