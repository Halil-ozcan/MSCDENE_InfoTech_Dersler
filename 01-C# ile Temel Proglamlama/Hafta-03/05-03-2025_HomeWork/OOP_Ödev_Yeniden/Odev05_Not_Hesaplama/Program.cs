namespace Odev05_Not_Hesaplama;

class Program
{
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
        Student[] students = [
            new Student("Halil"),
            new Student("Mert"),
            new Student("Hakan"),
        ];

        Random rnd = new Random();
        for (int i = 0; i < students.Length; i++)
        {
            for (int j = 0; j<=3; j++)
            {
                int grade;
                do
                {
                    grade = rnd.Next(1,101);
                } while (grade % 5 == 0);
                students[i].AddGrades(grade);
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
