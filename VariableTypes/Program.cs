// See https://aka.ms/new-console-template for more information

int inum = 4;
byte bnum = 6;
long lnum = 1_000_000;
short snum = 3;
double dnum = 3e15;
float fnum = 1.9e4f;
decimal decnum = 1.9e4m;
char aLetter = 'a';
string letters = "This is a string";
bool aBool = true;
bool bBool = false;

inum = inum + 1;
lnum = lnum + 1_000;
snum = 30;
dnum = 2.454e44;
fnum = 4.4e4f;
decnum = 2.99m;
aLetter = 'b';
letters = "This is a new string";
aBool = false;
bBool = true;


Console.WriteLine("int: " + inum);
Console.WriteLine("byte: " + bnum);
Console.WriteLine("long: " + lnum);
Console.WriteLine("short: " + snum);
Console.WriteLine("double: " + dnum);
Console.WriteLine("float: " + fnum);
Console.WriteLine("decimal: " + decnum);
Console.WriteLine("char: " + aLetter);
Console.WriteLine("string: " + letters);
Console.WriteLine("bool: " + aBool);
Console.WriteLine("bool: " + bBool);
