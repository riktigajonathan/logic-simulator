using Godot;
using System;
using System.Net.NetworkInformation;
using static Godot.TextServer;

public partial class ComponentView : Node2D
{
	private CircuitComponent _component;

    [Export] private VBoxContainer _inputContainer;
    [Export] private VBoxContainer _outputContainer;

    public void Init(CircuitComponent component)
    {
        _component = component;
    }

    public void AddPin(Pin pin)
    {
        var pinScene = GD.Load<PackedScene>("res://Scenes/PinView.tscn");

        pin.View = pinScene.Instantiate<PinView>();
        pin.View.Init(pin);

        var targetContainer = pin.Direction == PinDirection.Input ? _inputContainer : _outputContainer;
        targetContainer.AddChild(pin.View);
    }
}
