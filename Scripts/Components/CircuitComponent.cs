using Godot;
using System;
using System.Collections.Generic;

public abstract partial class CircuitComponent
{
    public ComponentView View;
    
    public List<Pin> Inputs { get; } = new();
    public List<Pin> Outputs { get; } = new();

    protected CircuitComponent()
    {
        var scene = GD.Load<PackedScene>("res://Scenes/ComponentView.tscn");

        View = scene.Instantiate<ComponentView>();
        View.Init(this);
    }

    protected Pin AddInput()
    {
        var pin = new Pin(this, PinDirection.Input, Inputs.Count);
        View.AddPin(pin);

        Inputs.Add(pin);
        return pin;
    }

    protected Pin AddOutput()
    {
        var pin = new Pin(this, PinDirection.Output, Outputs.Count);
        View.AddPin(pin);

        Outputs.Add(pin);
        return pin;
    }

    public abstract void Evaluate();
}