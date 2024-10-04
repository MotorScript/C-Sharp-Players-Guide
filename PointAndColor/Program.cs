// See https://aka.ms/new-console-template for more information


Point points1 = new Point(2, 3);
Point points2 = new Point(-4, 0);

Console.WriteLine($"({points1.X}, {points1.Y})");
Console.WriteLine($"({points2.X}, {points2.Y})");

Color color1 = new Color(255, 175, 200);
Color color2 = Color.CreateWhite();

Console.WriteLine($"{color1.Red}, {color1.Green}, {color1.Blue}");
Console.WriteLine($"{color2.Red}, {color2.Green}, {color2.Blue}");


public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int xPoint, int yPoint)
    {
        X = xPoint;
        Y = yPoint;
    }

    public Point()
    {
        X = 0;
        Y = 0;
    }
    
    
}

public class Color
{
    public int Red { get; init; }
    public int Green { get; init; }
    public int Blue { get; init; }

    public Color(int red, int green, int blue)
    {
        if (red > 255 || green > 255 || blue > 255 || red < 0 || green < 0 || blue < 0)
        {
            
        }
        else
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }

    public static Color CreateWhite()
    {
        return new Color(255, 255, 255);
    }
    
    public static Color CreateBlack()
    {
        return new Color(0, 0, 0);
    }
    
    public static Color CreateRed()
    {
        return new Color(255, 0, 0);
    }
    
    public static Color CreateGreen()
    {
        return new Color(0, 255, 0);
    }
    
    public static Color CreateBlue()
    {
        return new Color(0, 0, 255);
    }
    
}