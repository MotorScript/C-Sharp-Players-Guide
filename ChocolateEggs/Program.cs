// See https://aka.ms/new-console-template for more information

Console.WriteLine("How many chocolate eggs were collected today?");
int chocoEggs = int.Parse(Console.ReadLine());

int eggsForEach = chocoEggs / 3;
int eggsForDuckbear = chocoEggs % 3;

Console.WriteLine("You will each receive " + eggsForEach + " chocolate eggs and the duckbear will receive " +
                  eggsForDuckbear + " eggs."); 