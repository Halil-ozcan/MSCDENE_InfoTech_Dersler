using System;

namespace Alistirma03;

public class Movie
{
    public Movie(string title, string director, int year, double ıMDBRating)
    {
        Title = title;
        Director = director;
        Year = year;
        IMDBRating = ıMDBRating;
    }

    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public double IMDBRating { get; set; }
    
    public void ShowDetails()
    {
        Console.WriteLine($"Film Adı: {Title}\n Yöntemen: {Director}\nYayın Yılı: {Year}\nIMDB Puanı: {IMDBRating}\n");
    }

}

