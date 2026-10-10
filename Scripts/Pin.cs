using Godot;
using System;

public partial class Pin
{
    public CircuitComponent Owner { get; }
    public PinDirection Direction { get; }
    public int Index { get; }
}

public enum PinDirection
{
    Input, 
    Output
}
