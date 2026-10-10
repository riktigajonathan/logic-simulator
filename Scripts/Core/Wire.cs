using Godot;
using System;

public partial class Wire
{
    public Pin Source { get; }
    public Pin Destination { get; }

    public Wire(Pin source, Pin destination)
    {
        if (source.Direction != PinDirection.Output)
            throw new ArgumentException("wire source must be an output");

        if (destination.Direction != PinDirection.Input)
            throw new ArgumentException("wire destination must be an input");

        Source = source;
        Destination = destination;
    }
}
