using System;
using ECommerceApp.Backend.Business.Abstract;
using ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Backend.Business.Concrete;

public class ImageService : IImageService
{
    private readonly string _imageFolderPath;
    public ImageService()
    {
        // C:\Users\Engin Niyazi\Documents\GitHub\Infotech-MSCD-ENE-8\07-KatmanlıMimari\Hafta10\21-04-2025\ECommerceApp\Backend\ECommerceApp.Backend.API\wwwroot\images
        _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
    }
    public void DeleteImage(string imageUrl)
    {
        // imageUrl: categories/a93c1355-7e1b-400d-9f89-8ff47e69fae2.png
        try
        {
            var fileFullPath = Path.Combine(_imageFolderPath, imageUrl);
            File.Delete(fileFullPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string GetDefaultImage(string folder)
    {
        // return Path.Combine("images",folder, folder=="categories" ? "default-category.png" : "default-product.png");
        return Path.Combine("images", folder, $"default-{folder}");
    }

    public bool ImageExists(string imageUrl)
    {
        try
        {
            var fileFullPath = Path.Combine(_imageFolderPath, imageUrl);
            return File.Exists(fileFullPath);
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<ResponseDTO<string>> UploadImageAsync(IFormFile image, string folder)
    {
        try
        {
            if (image is null)
            {
                return ResponseDTO<string>.Fail("Resim gönredilemedi!", StatusCodes.Status400BadRequest);
            }
            if (image.Length == 0 || image.Length > 5 * 1024 * 1024)
            {
                return ResponseDTO<string>.Fail("Resim 0-5 mb boyutunda olmalıdır!", StatusCodes.Status400BadRequest);
            }
            string[] allowedExtensions = [".png", ".jpg", ".jpeg", ".bmp", ".gif"];
            var imageExtension = Path.GetExtension(image.FileName);//.png
            if (!allowedExtensions.Contains(imageExtension))
            {
                return ResponseDTO<string>.Fail("Geçersiz resim türü. Geçerli türler: .png,.jpg,.jpeg,.bmp,.gif", StatusCodes.Status400BadRequest);
            }
            //a93c1355-7e1b-400d-9f89-8ff47e69fae2.png
            var fileName = $"{Guid.NewGuid()}{imageExtension}";
            // C:\Users\Engin Niyazi\Documents\GitHub\Infotech-MSCD-ENE-8\07-KatmanlıMimari\Hafta10\21-04-2025\ECommerceApp\Backend\ECommerceApp.Backend.API\wwwroot\images\categories  
            var folderPath = Path.Combine(_imageFolderPath, folder);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileFullPath = Path.Combine(folderPath, fileName);
            using var stream = new FileStream(fileFullPath, FileMode.Create);
            await image.CopyToAsync(stream);
            //  categories/a93c1355-7e1b-400d-9f89-8ff47e69fae2.png
            var imageUrl = Path.Combine(folder, fileName);
            return ResponseDTO<string>.Success(imageUrl, "Resim başarıyla yüklendi", StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return ResponseDTO<string>.Fail($"Beklenmedik Hata: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}
