Console.Title = "Battle of Consolas"; // Not supported on Mac or Linux according to ChatGPT
Console.Write($"Target Row? ");
int targetRow = int.Parse(Console.ReadLine());


Console.Write("Target Column? ");
int targetColumn = int.Parse(Console.ReadLine());

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine($@"({targetRow + 1}, {targetColumn})");
Console.WriteLine($@"({targetRow}, {targetColumn + 1})");
Console.WriteLine($@"({targetRow - 1}, {targetColumn})");
Console.WriteLine($@"({targetRow}, {targetColumn - 1})");

Console.Beep();