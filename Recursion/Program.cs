// See https://aka.ms/new-console-template for more information

int CountDown(int num)
{
    Console.WriteLine(num);
    if (num == 0)
    {
        return 0;
    }

    return CountDown(num - 1);
}

CountDown(33);