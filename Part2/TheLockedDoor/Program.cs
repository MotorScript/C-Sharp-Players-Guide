// See https://aka.ms/new-console-template for more information

Door door1 = new Door(DoorState.Locked, "CrackThisHacker");

Console.WriteLine(door1.State);

door1.State = DoorState.Open;

Console.WriteLine(door1.State);

class Door
{
    private DoorState _state;
    private string Passkey { get; } 
    public DoorState State
    {
        get => _state;

        set
        {
            
            switch (value)
            {
                case DoorState.Locked:
                    if (_state == DoorState.Open)
                    {
                    }
                    else
                    {
                        _state = value;
                    }
                    
                    break;
                
                case DoorState.Open:
                    if (_state == DoorState.Locked)
                    {
                        _state = UnlockDoor();
                    }
                    else if (_state == DoorState.Closed)
                    {
                        _state = value;
                    }

                    break;
                case DoorState.Closed:
                    _state = value;
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

        if (response == Passkey) return DoorState.Open;
        else return DoorState.Locked;
        
    }
    
}
enum DoorState{Open, Locked, Closed}