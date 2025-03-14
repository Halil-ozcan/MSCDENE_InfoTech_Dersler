namespace Alistirma03;

class Program
{
    static void Main(string[] args)
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie("The Shawshank Redemption","Frank Darabont",1994,9.3),
            new Movie("The Godfather","Francis Ford Coppola",1972,9.2),
            new Movie("The Dark Knight","Christopher Nolan",2008,8.0),
            new Movie("Pulp Fiction","Quentin Tarantino",1994,8.9),
            new Movie("Fight Club","David Fincher",1999,8.8),
        };

        Console.WriteLine("TÜM FİLMLER:\n");
        foreach (Movie movie in movies)
        {
            movie.ShowDetails();
        }

        var highestRatedMovie = movies.OrderByDescending(m=>m.IMDBRating).First();
        Console.WriteLine("En yüksek IDMB puanına sahip film: ");
        highestRatedMovie.ShowDetails();

        Console.WriteLine("Filmleri yayın yılına göre sıralamak ister misiniz? (E/H)");
        string choice = Console.ReadLine()!;
        if(choice?.ToUpper() == "E")
        {
            var sortedMovies = movies.OrderBy(m=>m.Year).ToList();
            Console.WriteLine("Yayın yılına göre sıralanmış filmler: ");
            foreach (Movie movie in sortedMovies)
            {
                movie.ShowDetails();
            }
        }
    }
}
