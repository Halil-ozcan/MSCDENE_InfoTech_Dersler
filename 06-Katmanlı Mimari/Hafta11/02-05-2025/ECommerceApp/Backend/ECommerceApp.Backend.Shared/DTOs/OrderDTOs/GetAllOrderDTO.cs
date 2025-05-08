using System;
using ECommerceApp.Backend.Shared.Enums;

namespace ECommerceApp.Backend.Shared.DTOs.OrderDTOs;

public class GetAllOrderDTO
{
    public GetAllOrderDTO(OrderStatus? orderStatus = null, string? appUserId = null, DateTime? startDate = null, DateTime? endDate = null, bool? isDeleted = null)
    {
        OrderStatus = orderStatus;
        AppUserId = appUserId;
        StartDate = startDate;
        EndDate = endDate;
        IsDeleted = isDeleted;
    }

    public OrderStatus? OrderStatus { get; set; } = null;
    public string? AppUserId { get; set; } = null;
    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;
    public bool? IsDeleted { get; set; } = null;
}
