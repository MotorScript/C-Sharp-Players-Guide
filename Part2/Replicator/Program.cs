// See https://aka.ms/new-console-template for more information


int[] userArray = new int[5];

// Allowing the user to enter values into the first array
for (int i = 0; i < userArray.Length; i++)
{
    Console.Write($"Enter a number to go in the {i} spot in the array: ");
    userArray[i] = int.Parse(Console.ReadLine());
}

// Creating a new array to copy values over from the original
int[] copyArray = new int[5];

// Copying the values of the user array into the copy
for (int i = 0; i < 5; i++)
{
    copyArray[i] = userArray[i];
}

// Printing contents of each array to prove they are the same
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"User: {userArray[i]}, Copy: {copyArray[i]}");
}
