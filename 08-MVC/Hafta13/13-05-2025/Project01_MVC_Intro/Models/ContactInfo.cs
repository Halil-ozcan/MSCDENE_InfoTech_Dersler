using System;

namespace Project01_MVC_Intro.Models;

public class ContactInfo
{
    public ContactInfo(string email, string city, string phoneNumber)
    {
        Email = email;
        City = city;
        PhoneNumber = phoneNumber;
    }

    public string Email { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
