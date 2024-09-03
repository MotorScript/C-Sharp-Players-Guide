// See https://aka.ms/new-console-template for more information

Console.Write("X Position of Enemy: ");

int xPosition = int.Parse(Console.ReadLine());

Console.Write("Y Position of Enemy: ");

int yPosition = int.Parse(Console.ReadLine());

bool north = (xPosition == 0) && (yPosition > 0);
bool northEast = (xPosition > 0) && (yPosition > 0);
bool east = (xPosition > 0) && (yPosition == 0);
bool southEast = (xPosition > 0) && (yPosition < 0);
bool south = (xPosition == 0) && (yPosition < 0);
bool southWest = (xPosition < 0) && (yPosition < 0);
bool west = (xPosition < 0) && (yPosition == 0);
bool northWest = (xPosition < 0) && (yPosition > 0);


if (north) Console.WriteLine("The Enemy is north of the watch tower!");
else if (northEast) Console.WriteLine("The Enemy is north east of the watch tower!");
else if (east) Console.WriteLine("The Enemy is east of the watch tower!");
else if (southEast) Console.WriteLine("The Enemy is south east of the watch tower!");
else if (south) Console.WriteLine("The Enemy is south of the watch tower!");
else if (southWest) Console.WriteLine("The Enemy is south west of the watch tower!");
else if (west) Console.WriteLine("The Enemy is west of the watch tower!");
else if (northWest) Console.WriteLine("The Enemy is north west of the watch tower!");
else Console.WriteLine("The Enemy is at the watch tower!!");



