// See https://aka.ms/new-console-template for more information

int GetUserInput(string prompt)
{
    Console.Write(prompt);
    return Convert.ToInt32(Console.ReadLine());
}

int arrowHeadChoice;
do
{
    arrowHeadChoice = GetUserInput(
        @"Which type of arrowhead would you like? 

            1 - Steel
            2 - Wood
            3 - Obsidian
");
    if (arrowHeadChoice == 1 || arrowHeadChoice == 2 || arrowHeadChoice == 3)
    {
        break;
    }
    else
    {
        Console.WriteLine("Please choose a valid option!");
    }
} while (arrowHeadChoice != 1 && arrowHeadChoice != 2 && arrowHeadChoice != 3);

int fletchingChoice;
do
{
    fletchingChoice = GetUserInput(
        @"Which type of fletching would you like? 

            1 - Plastic
            2 - Turkey
            3 - Goose
");

    if (fletchingChoice == 1 || fletchingChoice == 2 || fletchingChoice == 3)
    {
        break;
    }
    else
    {
        Console.WriteLine("Please choose a valid option!");
    }
} while (fletchingChoice != 1 && fletchingChoice != 2 && fletchingChoice != 3);

int shaftLength;
do
{
    shaftLength = GetUserInput(@"How long would you like the shaft to be? (6-35) ");

    if (shaftLength < 6 || shaftLength > 35)
    {
        Console.WriteLine("Please choose a valid option!");
    }
    else
    {
        break;
    }
} while (shaftLength < 6 || shaftLength > 35);

ArrowHeadMaterial arrowHead = arrowHeadChoice switch
{
    1 => ArrowHeadMaterial.Steel,
    2 => ArrowHeadMaterial.Wood,
    3 => ArrowHeadMaterial.Obsidian
};

FletchingType fletching = fletchingChoice switch
{
    1 => FletchingType.Plastic,
    2 => FletchingType.Turkey,
    3 => FletchingType.Goose
};

Arrow userArrow = new Arrow(arrowHead, fletching, shaftLength);

Console.WriteLine($"The total cost of your arrow is {userArrow.GetCost()} gold");


class Arrow
{
    public ArrowHeadMaterial _arrowHead;
    public FletchingType _fletching;
    public int _shaftLength;

    public Arrow(ArrowHeadMaterial arrowHead, FletchingType fletching, int shaftLength)
    {
        _arrowHead = arrowHead;
        _fletching = fletching;
        _shaftLength = shaftLength;
    }

    public float GetCost()
    {
        int steelPrice = 10;
        int woodPrice = 3;
        int obsidianPrice = 5;
        int plasticPrice = 10;
        int turkeyPrice = 5;
        int goosePrice = 3;
        float shaftPrice = 0.5F;
        float total = 0F;

        if (_arrowHead == ArrowHeadMaterial.Steel)
        {
            total += steelPrice;
        }
        else if (_arrowHead == ArrowHeadMaterial.Wood)
        {
            total += woodPrice;
        }
        else if (_arrowHead == ArrowHeadMaterial.Obsidian)
        {
            total += obsidianPrice;
        }

        if (_fletching == FletchingType.Plastic)
        {
            total += plasticPrice;
        }
        else if (_fletching == FletchingType.Turkey)
        {
            total += turkeyPrice;
        }
        else if (_fletching == FletchingType.Goose)
        {
            total += goosePrice;
        }

        total += (shaftPrice * _shaftLength);

        return total;
    }
}

enum ArrowHeadMaterial {Steel, Wood, Obsidian}
enum FletchingType {Plastic, Turkey, Goose}