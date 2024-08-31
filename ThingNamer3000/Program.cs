// See https://aka.ms/new-console-template for more information

Console.WriteLine("What kind of thing are we talking about?");
// Storing the type of thing we are talking about
string a = Console.ReadLine();
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
/* Description of variable stored as "a" */
string b = Console.ReadLine();
// Strings to be added to our previous two variables
string c = "of Doom";
string d = "3000";
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");