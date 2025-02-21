// Bu çalışmada C# içerisinde sayılarla ilgili işlemlerden bazılarını konuşuyor olacağız.
int a = 15;
int b = 2;
int result;

result = a + b;
result = a - b;
result = a * b;
result = a / b;
result = a % b;

Console.WriteLine($"a değişkenin ilk değeri : {a}");
result = a++; // Önce atama işlemi yapılır. sonra a'nın değerini bir arttır demek. Dolayısıyla bu satır sonrasında result'ın içinde 15, ama a'nın içinde 16 vardır.
Console.WriteLine($"resukt değişkenin  değeri : {result}");
Console.WriteLine($"a değişkenin son değeri : {a}");
