// See https://aka.ms/new-console-template for more information


float ropePrice = 10;
float torchPrice = 15;
float climbingEquipmentPrice = 25;
float waterPrice = 1;
float machetePrice = 20;
float canoePrice = 200;
float foodPrice = 1;


Console.Write(@"The following items are available:

    1 - Rope
    2 - Torches
    3 - Climbing Equipment
    4 - Clean Water
    5 - Machete
    6 - Canoe
    7 - Food

    Enter a corresponding number to get the price of each item: ");

int choice = int.Parse(Console.ReadLine());

Console.Write("\nWhat is your name? ");
string name = Console.ReadLine().ToLower();

if (name == "frodo")
{
    ropePrice = ropePrice / 2;
    torchPrice = torchPrice / 2;
    climbingEquipmentPrice = climbingEquipmentPrice / 2;
    waterPrice = waterPrice / 2;
    machetePrice = machetePrice / 2;
    canoePrice = canoePrice / 2;
    foodPrice = foodPrice / 2;
}

string response = choice switch
{
    1 => $"Rope costs {ropePrice} gold",
    2 => $"Torches cost {torchPrice} gold",
    3 => $"Climbing Equipment costs {climbingEquipmentPrice} gold",
    4 => $"Clean water costs {waterPrice} gold",
    5 => $"A machete costs {machetePrice} gold",
    6 => $"A canoe costs {canoePrice} gold",
    7 => $"Food costs {foodPrice} gold",
    _ => "Not a valid option"
};
Console.WriteLine($"\n\n\t{response}");

    