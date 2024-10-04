// See https://aka.ms/new-console-template for more information

Console.WriteLine("How many provinces do you own?");
int provinces = int.Parse(Console.ReadLine());

Console.WriteLine("How many duchies do you own?");
int duchies = int.Parse(Console.ReadLine());

Console. WriteLine("How many estates do you own?");
int estates = int.Parse(Console.ReadLine());

int totalPoints = ((provinces * 6) + (duchies * 3) + (estates));

Console.WriteLine("You have " + totalPoints + " points from your provinces, duchies, and estates!");