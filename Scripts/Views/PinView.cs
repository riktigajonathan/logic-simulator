using Godot;
using System;

public partial class PinView : Control
{
	private Pin _pin;

    public void Init(Pin pin)
	{
		_pin = pin;
    }
}
