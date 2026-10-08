using Godot;
using System;

public partial class Camera2d : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    private bool mouseDown = false;
    private Vector2 originalPos = Vector2.Zero;
    private Vector2 originalMousePos = Vector2.Zero;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            mouseDown = mouseButton.Pressed;

            if (mouseDown)
            {
                originalPos = Position;
                originalMousePos = mouseButton.Position;
            }
        }
        if (mouseDown && @event is InputEventMouseMotion mouseMotion)
        {
            Vector2 mouseDelta = mouseMotion.Position - originalMousePos;
            Position = originalPos - mouseDelta;
        }
    }
}
