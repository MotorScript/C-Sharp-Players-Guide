// See https://aka.ms/new-console-template for more information

int numToGuess = AskForNumber("User1, please enter a number: ", 1, 100);

Console.Clear();

int guess = 0;

while (guess != numToGuess)
{
    guess = AskForNumber("User2, enter a guess between 0 and 100: ", 1, 100);

    if (guess > numToGuess) Console.WriteLine("That number is too high");
    else if (guess < numToGuess) Console.WriteLine("That number is too low");
    else Console.WriteLine($"You guessed correctly! The number was {numToGuess}");
}

int AskForNumber(string text, int min, int max)
{

    while (true)
    {
        Console.Write(text);
        int number = int.Parse(Console.ReadLine());
        if (number > max || number < min)
        {
            Console.WriteLine("Please try again. That number did not meet the requirements");
        }
        else
        {
            return number;
        }

    }
    
}
