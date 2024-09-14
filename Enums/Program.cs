// See https://aka.ms/new-console-template for more information

Box boxState = Box.Open;

string GetResponse(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine();
}

Box ChangeState(Box currentState, Box desiredState)
{
    if (currentState == Box.Locked && desiredState == Box.Open)
    {
        Console.WriteLine("Try again, that is not a valid option since the box is locked. Unlock the box first.");
        return currentState;
    }
    else if (currentState == desiredState)
    {
        Console.WriteLine("The box is already in this state.");
        return currentState;
    }
    else if (currentState == Box.Open && desiredState == Box.Locked)
    {
        Console.WriteLine("Try again, the box is open and needs to be closed before you can lock it.");
        return currentState;
    }
    else
    {
        return desiredState;
    }
}


while (true)
{

    string response = GetResponse($"The box is {boxState.ToString().ToLower()} what would you like to do? ").ToLower();
    Box desiredState;
    if (response == "open")
    {
        desiredState = Box.Open;
    }
    else if (response == "lock")
    {
        desiredState = Box.Locked;
    }
    else if (response == "close")
    {
        desiredState = Box.Closed;
    }
    else if (response == "unlock")
    {
        desiredState = Box.Closed;
    }
    else
    {
        Console.WriteLine("That is not a valid entry. Please enter one of the following: open, close, lock, unlock.");
        continue;
    }

    boxState = ChangeState(boxState, desiredState);
}

enum Box {Open, Locked, Closed}
