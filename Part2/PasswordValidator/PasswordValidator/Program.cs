// See https://aka.ms/new-console-template for more information
while(true){
    Console.Write("\n\nEnter a password: ");

    string userPassword = Console.ReadLine();

    PasswordValidator password = new PasswordValidator(userPassword);

    Console.WriteLine($"\nPassword contains number: {password.ContainsNum}\n" +
                      $"Password contains capital letter: {password.ContainsCapital}\n" +
                      $"Password contains lower case letter: {password.ContainsLower}\n" +
                      $"Password meets length requirements: {password.MeetsLength}\n" +
                      $"Password meets abstract requirements: {password.MeetsAbstract}");

    if (!password.ContainsNum)
    {
        Console.WriteLine("\nYou need to add a number to your password. Please try again.");
    }

    if (!password.ContainsCapital)
    {
        Console.WriteLine("\nYou will need a capitol letter for your password. Please try again.");
    }

    if (!password.ContainsLower)
    {
        Console.WriteLine("\nYou need a lower case letter in your password. Please try again.");
    }

    if (!password.MeetsLength)
    {
        Console.WriteLine("\nYour password does not meet the length requirements of the password which is 8 characters. Please try again.");
    }

    if (!password.MeetsAbstract)
    {
        Console.WriteLine("\nYour password either contains a capital T or an ampersand (&). Please remove it to continue.");
    }

    if (password.ContainsLower && password.MeetsAbstract && password.MeetsLength && password.ContainsCapital &&
        password.ContainsNum)
    {
        Console.WriteLine("\nYou have created a password that meets all the requirements!! Good job!");
    }
}

class PasswordValidator
{
    private string _password;
    private int _passwordLength;
    private const int _lengthRequirement = 8;
    private char[] numbers = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public bool ContainsNum = false;
    public bool ContainsCapital = false;
    public bool ContainsLower = false;
    public bool MeetsLength = false;
    public bool MeetsAbstract = true;
    
    public PasswordValidator(string password)
    {
        _password = password;
        _passwordLength = password.Length;

        if (_passwordLength >= _lengthRequirement) MeetsLength = true;
        
        foreach (char character in password)
        {
            
            if (character == 'T' || character == '&')
            {
                MeetsAbstract = false;
            }
            
            foreach (char num in numbers)
            {
                if (character == num)
                {
                    ContainsNum = true;
                    break;
                }
            }

            if (char.IsUpper(character))
            {
                ContainsCapital = true;
                continue;
            }
            
            if (char.IsLower(character))
            {
                ContainsLower = true;
                continue;
            }
        }
    }
}