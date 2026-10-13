using Godot;
using System;

public partial class Editor : Node2D
{
	private Circuit _circuit = new();

	public void OnCircuitChanged()
	{
		_circuit.Simulate();
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Gate gate = new(new int[] { 0, 1, 1, 0 }); // XOR gate truth table
        _circuit.Components.Add(gate); // XOR gate

		AddChild(gate.View);

        OnCircuitChanged();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        _circuit.Simulate();
    }
}
