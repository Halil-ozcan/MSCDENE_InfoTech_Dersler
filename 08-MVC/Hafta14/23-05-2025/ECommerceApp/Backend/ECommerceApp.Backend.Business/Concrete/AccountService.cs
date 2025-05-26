using System;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Entities.Concrete;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.OrderDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using ECommerceApp.Backend.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Backend.Business.Concrete;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IOrderService _orderService;
    public AccountService(UserManager<AppUser> userManager, IOrderService orderService)
    {
        _userManager = userManager;
        _orderService = orderService;
    }

    public async Task<ResponseDTO<AppUserDTO>> GetByIdAsync(string appUserId)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(appUserId);
            if (user is null)
            {
                return ResponseDTO<AppUserDTO>.Fail("Hata", StatusCodes.Status404NotFound);
            }
            var roles = await _userManager.GetRolesAsync(user);
            var orders = await _orderService.GetAllAsync(new GetAllOrderDTO(appUserId: appUserId));
            var appUserDto = new AppUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                Address = user.Address ?? string.Empty,
                City = user.City ?? string.Empty,
                DateOfBirth = user.DateOfBirth ?? DateTime.Now,
                Gender = user.Gender ?? Gender.None,
                Orders = orders.Data.ToList()
            };
            return ResponseDTO<AppUserDTO>.Success(appUserDto, "işlem başarılı", StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return ResponseDTO<AppUserDTO>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}