using Godot;
using System;

public partial class Pin
{
    public CircuitComponent Owner { get; }
    public PinDirection Direction { get; }
    public int Index { get; }

    public bool Value { get; set; } = false;

    public Pin(CircuitComponent owner, PinDirection direction, int index)
    {
        Owner = owner;
        Direction = direction;
        Index = index;
    }
}

public enum PinDirection
{
    Input, 
    Output
}
