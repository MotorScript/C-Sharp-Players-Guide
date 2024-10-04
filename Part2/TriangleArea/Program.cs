// See https://aka.ms/new-console-template for more information

Console.WriteLine("What is the height of the triangle?");
int triangleHeight = int.Parse(Console.ReadLine());
Console.WriteLine("What is the base of the triangle?");
int triangleBase = int.Parse(Console.ReadLine());

int triangleArea = (triangleBase * triangleHeight) / 2;

Console.WriteLine("The area of your triangle is: " + triangleArea);
