using Godot;

public partial class Camera2d : Camera2D
{
    [Export] public float ZoomStrength = 0.1f;
    [Export] public float MinZoom = 0.5f;
    [Export] public float MaxZoom = 3.0f;
    [Export] public float PanSpeed = 1.0f;

    private bool mouseDown = false;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left || 
                mouseButton.ButtonIndex == MouseButton.Middle)
            {
                mouseDown = mouseButton.Pressed;
            }

            if (mouseButton.ButtonIndex == MouseButton.WheelUp)
            {
                ZoomAtMouse(mouseButton.Position, ZoomStrength);
            }
            else if (mouseButton.ButtonIndex == MouseButton.WheelDown)
            {
                ZoomAtMouse(mouseButton.Position, -ZoomStrength);
            }
        }

        if (mouseDown && @event is InputEventMouseMotion mouseMotion)
        {
            Position -= mouseMotion.Relative / Zoom * PanSpeed;
        }
    }

    private void ZoomAtMouse(Vector2 mousePosition, float amount)
    {
        float oldZoom = Zoom.X;

        float newZoom = Mathf.Clamp(
            oldZoom + amount,
            MinZoom,
            MaxZoom
        );

        if (Mathf.IsEqualApprox(oldZoom, newZoom))
            return;

        Vector2 viewportCenter = GetViewportRect().Size / 2.0f;
        Vector2 mouseOffset = mousePosition - viewportCenter;

        Vector2 beforeZoom = GlobalPosition + mouseOffset / oldZoom;

        Zoom = Vector2.One * newZoom;

        Vector2 afterZoom = GlobalPosition + mouseOffset / newZoom;

        GlobalPosition += beforeZoom - afterZoom;
    }
}