using System;
using ECommerceApp.Backend.Shared.DTOs.AuthDTOs;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

namespace ECommerceApp.Backend.Business.Abstract;

public interface IAccountService
{
    Task<ResponseDTO<AppUserDTO>> GetByIdAsync(string appUserId);
}