namespace Alistirma01;

class Program
{

    static User TookTheMostSteps(User[] users)
    {
        User topUsers = users[0];
        for (int i = 0; i < users.Length; i++)
        {
            if(users[i].Steps>topUsers.Steps)
            {
                topUsers = users[i];
            }
        }
        return topUsers;
    }

    static void Main(string[] args)
    {
       User[] users = [
        new User("Halil Özcan", 24, 65.9 ,1.71),
        new User("Mert Hakan Yandaş", 30, 72.3, 1.75),
        new User("Bilal Koçyiğit", 36, 100, 1.87),
        new User("Ömer Güler", 19, 82, 1.85),
       ];

      Random rnd = new Random();

      foreach (User user in users)
      {
        user.AddSteps(rnd.Next(1,3000));
        user.ShowProgress();
      }

      User topUser = TookTheMostSteps(users);
      Console.WriteLine("---------------------------");
      Console.WriteLine($"En Fazla Adım Atan Kullanıcı: {topUser.Name}, Adım Sayısı: {topUser.Steps}");
       
    }
}
