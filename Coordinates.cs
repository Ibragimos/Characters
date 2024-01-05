using System;
public class Coordinates
{
    public int X { get; }
    public int Y { get; }

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Coordinates other)
    {
        return Math.Sqrt(Math.Pow(this.X - other.X, 2) + Math.Pow(this.Y - other.Y, 2));
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}