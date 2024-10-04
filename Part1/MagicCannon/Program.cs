// See https://aka.ms/new-console-template for more information

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0) Console.WriteLine($"{i}. Potent"); // When 5th and 3rd coincide e.g. 15
    else if (i % 3 == 0) Console.WriteLine($"{i}. Fire"); // Every 3rd line
    else if (i % 5 == 0) Console.WriteLine($"{i}. Electric"); // Every 5th line
    else Console.WriteLine($"{i}. Normal");
}