namespace Odev5_Grade_Managment;

class Program
{

    static int GetRandomNumber(int minValue, int maxValue, int factor)
    {
        Random random = new Random();
        int number;
        do
        {
            number = random.Next(minValue, maxValue+1);
        } while (number % factor !=0);
        return number;
    }

    static Student GetTopStudent(Student[] students)
    {
        Student topStudent = students[0];
        for (int i = 0; i < students.Length; i++)
        {
            if(students[i].CalculateAverage()>topStudent.CalculateAverage())
            {
                topStudent = students[i];
            }
        }
        return topStudent;
    }
    static void Main(string[] args)
    {
        Console.Clear();
        Student[] students =[
            new Student("Bestegül"),
            new Student("Edin"),
            new Student("Osimen")
        ];

        Random rnd = new Random();
        for (int i = 0; i < students.Length; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                // int grade;
                // do
                // {
                //     grade = rnd.Next(1,100);
                // } while (grade%5!=0);

                // students[i].AddGrade(grade);
                students[i].AddGrade(GetRandomNumber(1,100,5));
            }
        }

        foreach (Student student in students)
        {
            student.DisplayInfo();
        }
        Student topStudent = GetTopStudent(students);
        Console.WriteLine($"En yüksek not ortalamasına sahip öğrenci: {topStudent.Name}, Ortalaması: {topStudent.CalculateAverage():N2}");

    }
}
