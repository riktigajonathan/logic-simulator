using Godot;
using System;
using System.Collections.Generic;

public abstract class CircuitComponent
{
    public List<Pin> Inputs { get; } = new();
    public List<Pin> Outputs { get; } = new();

    protected Pin AddInput()
    {
        var pin = new Pin(this, PinDirection.Input, Inputs.Count);

        Inputs.Add(pin);
        return pin;
    }

    protected Pin AddOutput()
    {
        var pin = new Pin(this, PinDirection.Output, Outputs.Count);

        Outputs.Add(pin);
        return pin;
    }

    public abstract void Evaluate();
}