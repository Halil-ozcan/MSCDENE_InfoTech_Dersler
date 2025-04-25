using System;
using System.Text.Json.Serialization;

namespace ECommerceApp.Backend.Shared.DTOs.ResponseDTOs;

public class ResponseDTO<T>
{
    public T Data { get; set; } = default!;
    public bool IsSuccessful { get; set; }
    public string Message { get; set; } = null!;
    [JsonIgnore]
    public int StatusCode { get; set; }
    //Factory Design Pattern
    public static ResponseDTO<T> Success(T? data, string message, int statusCode)
    {
        return new ResponseDTO<T>
        {
            Data = data!,
            Message = message,
            StatusCode = statusCode,
            IsSuccessful = true
        };
    }

    public static ResponseDTO<T> Success(string message, int statusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default!,
            Message = message,
            StatusCode = statusCode,
            IsSuccessful = true
        };
    }

    public static ResponseDTO<T> Fail(string message, int statusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default!,
            Message = message,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }
}
