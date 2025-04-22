using System;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Backend.API.ControllerBases;

public class CustomControllerBase : ControllerBase
{
    public static IActionResult CreateResult<T>(ResponseDTO<T> response)
    {
        return new ObjectResult(response) { StatusCode = response.StatusCode };
    }
}
