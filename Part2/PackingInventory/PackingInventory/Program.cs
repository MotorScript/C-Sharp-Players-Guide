// See https://aka.ms/new-console-template for more information

// Function to create the pack for the user
Pack CreatePack() 
{
    Console.WriteLine("Please create a pack to contain your items");
    Console.Write("Please enter a maximum weight: ");
    float packWeight = Convert.ToInt32(Console.ReadLine());

    Console.Write("Please enter a maximum volume: ");
    float packVolume = Convert.ToInt32(Console.ReadLine());

    Console.Write("Please enter a maximum item count: ");
    int packMaxItems = Convert.ToInt32(Console.ReadLine());

    return new Pack(packWeight, packVolume, packMaxItems);
}


// Generic function to get user input, returns int
int GetUserInput(string output)
{
    Console.WriteLine(output);

    string userChoice = Console.ReadLine();

    return Convert.ToInt32(userChoice);

}


// Adds an item to a "Pack" class item that is passed, returns false if item could not be added
bool AddItemToPack(Pack pack)
{
    
    string itemUserPrompt = @"Pick from the following options to add to your pack
                                                                         Weight      Volume
                                                             1 Arrow     0.01        0.05
                                                             2 Bow       1           4
                                                             3 Rope      1           1.5
                                                             4 Water     1           3
                                                             5 Food      1           0.5
                                                             ";
    int response = GetUserInput(itemUserPrompt);

    while (1 > response || response > 5)
    {
        Console.WriteLine("\nYou need to choose a valid number between 1-5\n");
        response = GetUserInput(itemUserPrompt);
    }

    InventoryItem itemToAdd = response switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food()
    };

    if (pack.Add(itemToAdd)) return true;
    else
    {
        Console.WriteLine("The pack will not fit that item");
        return false;
    }
}

Pack usersPack = CreatePack();

while (
    ((usersPack.MaxWeight - usersPack.CurrentWeight) >= 0.01) &&
    ((usersPack.MaxItems - usersPack.CurrentItemCounter) > 0) &&
    ((usersPack.MaxVolume - usersPack.CurrentVolume) >= 0.05))
{
    Console.Clear();
    Console.WriteLine(usersPack.ToString());
    Console.WriteLine($"\nMaximum number of items pack can hold: {usersPack.MaxItems}");
    Console.WriteLine($"Current number of items in pack: {usersPack.CurrentItemCounter}\n");
    if (AddItemToPack(usersPack)) Console.WriteLine("\n\nItem was added successfully to pack\n\n");
    else
    {
        Console.WriteLine("That item could not be added to the pack.");
    }
}
// Parent class for InventoryItems.
public abstract class InventoryItem
{
    public float Weight { get; set; }
    public float Volume { get; set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }


}

// Child classes of InventoryItem
public class Arrow : InventoryItem
{
    public Arrow() : base(0.01f, 0.05f)
    {
        
    }

    public override string ToString()
    {
        return "Arrow";
    }

}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f)
    {
        
    }

    public override string ToString()
    {
        return "Bow";
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f)
    {
        
    }

    public override string ToString()
    {
        return "Rope";
    }
}

public class Water : InventoryItem
{
    public Water() : base(1f, 3f)
    {
        
    }

    public override string ToString()
    {
        return "Water";
    }
}

public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f)
    {
        
    }

    public override string ToString()
    {
        return "Food";
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f)
    {
        
    }
    
    public override string ToString()
    {
        return "Sword";
    }
}

public class Pack
{
    private float _maxWeight;
    private float _maxVolume;
    private int _maxItems;

    private InventoryItem[] _items;
    
    // These properties only allow changing of themselves through the class, "private"
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }
    public int CurrentItemCounter { get; private set; }

    public float MaxWeight
    {
        get => _maxWeight;
    }

    public float MaxVolume
    {
        get => _maxVolume;
    }

    public int MaxItems
    {
        get => _maxItems;
    }


    public Pack(float maxWeight, float maxVolume, int maxItems)
    {
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        _maxItems = maxItems;
        _items = new InventoryItem[maxItems];
    }

    public override string ToString()
    {
        string contents = "This pack contains ";
        if (CurrentItemCounter == 0) contents += "Nothing";
        for (int itemNumber = 0; itemNumber < CurrentItemCounter; itemNumber++)
        {
            contents += _items[itemNumber].ToString() + " ";
        }

        return contents;
    }
    public bool Add(InventoryItem item)
    {
        if (CurrentItemCounter >= _maxItems) return false;
        if (CurrentWeight + item.Weight > _maxWeight) return false;
        if (CurrentVolume + item.Volume > _maxVolume) return false;

        _items[CurrentItemCounter] = item;
        CurrentItemCounter++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }


}