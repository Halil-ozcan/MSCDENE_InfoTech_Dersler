namespace Proje13_Sayi_Tahmin_Oyunu;

class Program
{

    static void printColored(string message, ConsoleColor color, bool lineStatus=true)
    {
        Console.ForegroundColor=color; // consoldaki yazı rengini istediğimiz renge dönüştürmek için kullanıyoruz.
        if(lineStatus)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
        Console.WriteLine(message);
        Console.ResetColor(); // burda da tekrar default renge döndürmek için kullanıyoruz.
    }

    static int GetValidGuess(int remainingLives)
    {
        int guess;//tahmin
        while(true)
        {
            printColored($"Tahmininizi Giriniz(1-100) (Kalan Can: {remainingLives}): ", ConsoleColor.DarkYellow, false);
            string input = Console.ReadLine()!;
            if(int.TryParse(input, out guess) && guess>=1 && guess<=100)
            {
                return guess;
            }
        }
    }

    static string EvaluateGuess(int guess, int targetNumber)
    {
        
    }

    static void StartGame()
    {
        Console.Clear();
        Random rnd = new Random();
        int targetNumber = rnd.Next(1,101);//1-100
        Console.WriteLine($"Hile: {targetNumber}", ConsoleColor.Gray);
        int guess; // tahmin
        int lives=5; // kullanıcı hakkı
        int score=100; // puan
        string message="";
        printColored("SAYİ TAHMİN OYUNUNA HOŞ GELDİNİZ!",ConsoleColor.DarkMagenta);
        printColored("1-100 arasındaki değerlerden tuttuğum rastgele sayıyı bulmaya çalışın.", ConsoleColor.DarkCyan);
        do
        {
           
            guess = GetValidGuess(lives); // Kullanıcının tahminini aldık.
            lives--; // yanlış yada doğru bir girdi girmesi halinde hakkını bir azalttık.
            if(lives>0)
            {
                // Girilen tahmin ile tutulan sayıyı karşılaştıracak metodumuzu yazmaya gidiyoruz.
                message=EvaluateGuess(guess, targetNumber);
            }

        } while (true);
    }
    static void Main(string[] args)
    {
      
       bool isPlayAgain;
       do
       {
           StartGame(); 
            Console.WriteLine();
            printColored("YENİDEN OYNAMAK İSTER MİSİNİZ?(E/H): ", ConsoleColor.DarkBlue, false);
            string response = Console.ReadLine()!.ToUpper();
            isPlayAgain =response=="E";
       } while (isPlayAgain);
       printColored("OYUN SONA ERDİ, YİNE BEKLERİZ!",ConsoleColor.Blue);
    }







}
