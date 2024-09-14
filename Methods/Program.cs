// See https://aka.ms/new-console-template for more information


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

int response = AskForNumber("Please enter a good number: ", 3, 99);
Console.WriteLine(response);