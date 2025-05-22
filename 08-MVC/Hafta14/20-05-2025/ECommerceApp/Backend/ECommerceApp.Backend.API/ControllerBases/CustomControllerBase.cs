using System;
using System.Security.Claims;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.ControllerBases;

public class CustomControllerBase : ControllerBase
{
    protected static IActionResult CreateResult<T>(ResponseDTO<T> response)
    {
        return new ObjectResult(response) { StatusCode = response.StatusCode };
    }
    protected string GetUserId()// bu metot o sırada login olmuş kullanıcının token bilgilerinden user id getirmeye yarar.
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return userId;
    }
}
