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
        if(guess>targetNumber)
        {
            return "Lütfen daha küçük bir sayi giriniz";
        }
        if(guess<targetNumber)
        {
            return "Lütfen daha büyük bir sayi giriniz";
        }
        return string.Empty;// "" anlamına geliyor.
    }

    static int CalculateScore(int remainingLives)
    {
        int score = remainingLives==0 ? 0 : remainingLives * 20;
        return score;
    }

    static void ShowGameResult(bool isWinner, int targetNumber, int score)
    {
        if(isWinner)
        {
            printColored("Tebrikler Kazandınız!", ConsoleColor.Green);
        }
        else
        {
            printColored($"Üzgünüm Kaybettiniz! Doğru Cevap: {targetNumber} olmalıydı.", ConsoleColor.Red);
        }
        printColored($"Puanınız: {score}", ConsoleColor.DarkCyan);
    }

    static void StartGame()
    {
        Console.Clear();
        Random rnd = new Random();
        int targetNumber = rnd.Next(1,101);//1-100
        // Console.WriteLine($"Hile: {targetNumber}", ConsoleColor.Gray);
        int guess; // tahmin
        int lives=5; // kullanıcı hakkı
        int score=100; // puan
        string message="";
        printColored("SAYİ TAHMİN OYUNUNA HOŞ GELDİNİZ!",ConsoleColor.DarkMagenta);
        printColored("1-100 arasındaki değerlerden tuttuğum rastgele sayıyı bulmaya çalışın.", ConsoleColor.DarkCyan);
        do
        {
           
            guess = GetValidGuess(lives); // Kullanıcının tahminini aldık.
            // yanlış yada doğru bir girdi girmesi halinde hakkını bir azalttık.
            if(lives>0)
            {
                // Girilen tahmin ile tutulan sayıyı karşılaştıracak metodumuzu yazmaya gidiyoruz.
                message=EvaluateGuess(guess, targetNumber);
                if(!string.IsNullOrEmpty(message))// mesajın içi boş değilse
                {
                    lives--; 
                    if(lives!=0)printColored(message, ConsoleColor.Blue,false);
                    printColored($"Kalan Can: {lives}", ConsoleColor.Yellow);
                }
            }

        } while (guess!=targetNumber && lives>0);
        // Bu noktada oyun bitmiş diyebiliriz.
        bool isWinner = guess==targetNumber;
        score = CalculateScore(lives);
        ShowGameResult(isWinner, targetNumber,score);
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

// Alt+0 ile metotları tek satır haline getirir.