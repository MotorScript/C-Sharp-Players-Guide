// See https://aka.ms/new-console-template for more information

// Get input from first user to set distance of Manticore
// Show status of game.
//      City Health
//      Manticore Health
//      Round Number
//      Blast Damage
// Get second user input to guess location of Manticore
// Check against location of Manticore 
// Award points accordingly
// Inform player2 whether their guess was too high or too low

int cityHealth = 15;
int mantiHealth = 10;
int round = 1;
int mantiLocation = GetInputInt("User1, what is the location of the Manticore in relation to the city of Consolas? " +
                                "(Enter a number between 1 and 100) ", 1, 100);

while (!isGameOver())
{
    if (round == 1)
    {
        Console.Clear();
    }   
    PlayRound();
    round++;
}

if (cityHealth <= 0)
{
    Console.WriteLine("\n\nYou lost, the Manticore has destroyed the city!");
}
else
{
    Console.WriteLine("\n\nYou won! You have destroyed the Manticore.");
}

int GetInputInt(string prompt, int min, int max)
{
    Console.Write(prompt);
    int response = Convert.ToInt32(Console.ReadLine());
    while (response < min || response > max)
    {
        Console.Write("Try again, that number was not valid: ");
        response = Convert.ToInt32(Console.ReadLine());
    }

    return response;
}

bool isGameOver()
{
    if (cityHealth <= 0 || mantiHealth <= 0)
    {
        return true;
    }

    return false;
}

void ShowStatus(int cityHealthStatus, int mantiHealthStatus, int roundNumber, int blastDamage)
{
    Console.WriteLine($@"
-----------------------------------------------------------------------------------------
STATUS Round: {round}   City Health: {cityHealthStatus}/15     Manticore Health: {mantiHealthStatus}/10
The cannon is expected to deal {blastDamage} points this round.");
}

int GetBlastDamage(int roundNumber)
{
    if ((roundNumber % 3 == 0) && (roundNumber % 5 == 0))
    {
        return 10;
    } 
    else if (roundNumber % 3 == 0)
    {
        return 3;
    }
    else if (roundNumber % 5 == 0)
    {
        return 3;
    }
    else return 1;
}

void PlayRound()
{
    int blastDamage = GetBlastDamage(round);
    
    ShowStatus(cityHealth, mantiHealth, round, blastDamage);
    int user2Guess = GetInputInt("User2, enter desired cannon range (1-100): ", 1, 100);

    if (user2Guess == mantiLocation)
    {
        mantiHealth -= blastDamage;
        Console.WriteLine($"You hit and dealt {blastDamage} damage to the Manticore!");
    }
    else if (user2Guess > mantiLocation)
    {
        Console.WriteLine("You overshot the Manticore! Enter a lower number next time.");
    }
    else if (user2Guess < mantiLocation)
    {
        Console.WriteLine("You undershot the Manticore! Enter a higher number next time.");
    }

    cityHealth--;

}
