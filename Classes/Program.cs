// See https://aka.ms/new-console-template for more information

int GetUserInput(string prompt)
{
    Console.Write(prompt);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintCost(Arrow arrow)
{
    Console.WriteLine($"The total cost of your arrow is {arrow.GetCost()} gold, and the shaft is {arrow.ShaftLength} inches long");
}

Arrow userArrow;
int userArrowChoice;
do
{
    userArrowChoice = GetUserInput(
        @"
    Please Choose one of the following options:

    1 - Beginner's Arrow
    2 - Marksman Arrow
    3 - Elite Arrow
    4 - Custom Arrow

");
    switch (userArrowChoice)
    {
        case 1:
            userArrow = Arrow.BeginnerArrow();
            PrintCost(userArrow);
            break;
        case 2:
            userArrow = Arrow.MarksmanArrow();
            PrintCost(userArrow);
            break;
        case 3:
            userArrow = Arrow.EliteArrow();
            PrintCost(userArrow);
            break;
        case 4:
            Console.Clear();
            userArrow = CreateCustomArrow();
            PrintCost(userArrow);
            break;
        default:
            Console.WriteLine("Sorry, that did not work. Please enter a valid number");
            Console.Clear();
            break;
    }

} while (userArrowChoice != 1 && userArrowChoice != 2 && userArrowChoice != 3 && userArrowChoice != 4);

Arrow CreateCustomArrow()
{
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
    Arrow customUserArrow = new Arrow(arrowHead, fletching, shaftLength);
    return customUserArrow;
}



class Arrow
{
    public ArrowHeadMaterial ArrowHead { get; init; }
    public FletchingType Fletching { get; init; }
    public int ShaftLength { get; init; }

    public Arrow(ArrowHeadMaterial arrowHead, FletchingType fletching, int shaftLength)
    {
        ArrowHead = arrowHead;
        Fletching = fletching;
        ShaftLength = shaftLength;
    }

    public static Arrow EliteArrow()
    {
        return new Arrow(ArrowHeadMaterial.Steel, FletchingType.Plastic, 35);
    }
    public static Arrow BeginnerArrow()
    {
        return new Arrow(ArrowHeadMaterial.Wood, FletchingType.Goose, 28);
    }
    public static Arrow MarksmanArrow()
    {
        return new Arrow(ArrowHeadMaterial.Steel, FletchingType.Goose, 30);
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

        if (ArrowHead == ArrowHeadMaterial.Steel)
        {
            total += steelPrice;
        }
        else if (ArrowHead == ArrowHeadMaterial.Wood)
        {
            total += woodPrice;
        }
        else if (ArrowHead == ArrowHeadMaterial.Obsidian)
        {
            total += obsidianPrice;
        }

        if (Fletching == FletchingType.Plastic)
        {
            total += plasticPrice;
        }
        else if (Fletching == FletchingType.Turkey)
        {
            total += turkeyPrice;
        }
        else if (Fletching == FletchingType.Goose)
        {
            total += goosePrice;
        }

        total += (shaftPrice * ShaftLength);

        return total;
    }
}

enum ArrowHeadMaterial {Steel, Wood, Obsidian}
enum FletchingType {Plastic, Turkey, Goose}