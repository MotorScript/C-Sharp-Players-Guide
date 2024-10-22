// See https://aka.ms/new-console-template for more information

int GetUserChoice(Door door)
{
    Console.WriteLine(@$"
-------------------------------------------------------------------
    What would you like to do? The current state is {door.State}.

    1. Open
    2. Close
    3. Lock
    4. Unlock
    5. Change Door Password
    6. Quit Program
------------------------------------------------------------------
    ");
    int response = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    return response;
}

void ChangePassword(Door door)
{
    bool passwordChanged = false;
    while(!passwordChanged)
    {
        Console.Write("What is your current password? ");
        string userEntry = Console.ReadLine();
        if (userEntry == door.Passkey)
        {
            Console.Clear();
            bool passwordsIdentical = false;
            while(!passwordsIdentical)
            {
                Console.Write("Please enter your new password: ");
                string passwordEntry1 = Console.ReadLine();
                Console.Write("Please enter the password again: ");
                string passwordEntry2 = Console.ReadLine();

                if (passwordEntry1 == passwordEntry2)
                {
                    door.Passkey = passwordEntry1;
                    passwordChanged = true;
                    passwordsIdentical = true;
                    Console.WriteLine("\n\nYour password has been changed successfully");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Those passwords did not match, please enter them again.");
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("That is not the correct password, please try again");
        }
    }
}

// Creating a door
Console.Write("Enter a password for unlocking your door: ");
string passkey = Console.ReadLine();
Door door1 = new Door(DoorState.Locked, passkey);


// User interaction while loop
bool playing = true;

while (playing)
{
    DoorState beginningState = door1.State;
    int userChoice = GetUserChoice(door1);

    switch (userChoice)
    {
        case 1:
            door1.State = DoorState.Open;
            break;
        case 2:
            door1.State = DoorState.Closed;
            break;
        case 3:
            door1.State = DoorState.Locked;
            break;
        case 4:
            door1.State = DoorState.Closed;
            break;
        case 5:
            ChangePassword(door1);
            break;
        case 6:
            playing = false;
            Console.WriteLine("Goodbye!");
            break;
    }

    if (playing && beginningState == door1.State)
    {
        Console.WriteLine("Your door state did not change.");
        continue;
    }

    Console.Clear();
}

class Door
{
    private DoorState _state;
    public string Passkey { get; set; } 
    public DoorState State
    {
        get => _state;

        set
        {
            // Switch statement checks the desired state against the current state to make sure it is not an invalid choice.
            // Putting this logic in the class and setter of the "State" property so that way the door can't be accidentally
            // moved to an invalid state somewhere else in the code.
            switch (value)
            {
                case DoorState.Locked:
                    if (_state == DoorState.Open)
                    {
                        Console.WriteLine("You need to close this door before you can lock it.");
                    }
                    else
                    {
                        _state = value;
                    }
                    
                    break;
                
                case DoorState.Open:
                    if (_state == DoorState.Locked)
                    {
                        Console.WriteLine("You need to unlock this door before you can open it.");
                    }
                    else if (_state == DoorState.Closed)
                    {
                        _state = value;
                    }

                    break;
                case DoorState.Closed:
                    if (_state == DoorState.Locked)
                    {
                        _state = UnlockDoor();
                    }
                    else
                    {
                        _state = value;
                    }
                    break;
            }
        }
        
    }
    
    public Door(DoorState state, string passkey)
    {
        _state = state;
        Passkey = passkey;
    }

    private DoorState UnlockDoor()
    {
        Console.Write("What is the passkey to unlock the door? ");
        string response = Console.ReadLine();

        if (response == Passkey) return DoorState.Closed;
        else return DoorState.Locked;
        
    }
    
}
enum DoorState{Open, Locked, Closed}