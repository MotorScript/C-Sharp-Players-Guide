// See https://aka.ms/new-console-template for more information

Console.Write("Enter a number: ");
int num =  int.Parse(Console.ReadLine());

bool isEven = (num % 2) == 0;

if (isEven)
{
    Console.WriteLine("Tick");
}
else
{
    Console.WriteLine("Tock");
}