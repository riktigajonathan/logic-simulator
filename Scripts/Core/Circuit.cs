using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Circuit
{
    public List<CircuitComponent> Components { get; } = new();
    public List<Wire> Wires { get; } = new();

    public void Simulate()
    {
        const uint maxIterations = 100;

        for (uint iteration = 0; iteration < maxIterations; iteration++)
        {
            bool changed = false;

            // make outputs flow through wires
            foreach (Wire wire in Wires)
            {
                bool value = wire.Source.Value;

                if (wire.Destination.Value != value)
                {
                    wire.Destination.Value = value;
                    changed = true;
                }
            }

            // calculate components
            foreach (CircuitComponent component in Components)
            {
                var previous = component.Outputs
                    .Select(pin => pin.Value)
                    .ToArray();

                component.Evaluate();

                for (int i = 0; i < component.Outputs.Count; i++)
                {
                    if (previous[i] != component.Outputs[i].Value)
                    {
                        changed = true;
                        break;
                    }
                }
            }

            if (!changed)
                return;
        }
    }
}
