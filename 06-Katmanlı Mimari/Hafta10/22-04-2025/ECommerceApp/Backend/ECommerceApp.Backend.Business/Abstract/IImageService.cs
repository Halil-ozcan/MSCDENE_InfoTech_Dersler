using System;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Business.Abstract;

public interface IImageService
{
    Task<ResponseDTO<string>> UploadImageAsync(IFormFile image, string folder);
    void DeleteImage(string imageUrl);
    bool ImageExists(string imageUrl);
    string GetDefaultImage(string folder);
}
