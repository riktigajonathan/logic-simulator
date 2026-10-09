using Godot;
using System;
using System.Collections.Generic;

public partial class Gate : Node2D
{
	private Dictionary<bool[], bool[]> truth_table = new();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		// Default to NOT gate
		if (this.truth_table == null)
		{

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}