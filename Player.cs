using Godot;

public partial class Player : Area2D
{
    [Signal]
    public delegate void ShootEventHandler(Vector2 direction, Vector2 location);

    private Vector2 screenSize; // Size of the game window.

    [Export] private int speed = 400; // How fast the player will move (pixels/sec).

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;
    }

    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right")) velocity.X += 1;

        if (Input.IsActionPressed("move_left")) velocity.X -= 1;

        if (Input.IsActionPressed("move_down")) velocity.Y += 1;

        if (Input.IsActionPressed("move_up")) velocity.Y -= 1;

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * speed;
            animatedSprite2D.Play();
        }
        else
        {
            animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            Mathf.Clamp(Position.X, 0, screenSize.X),
            Mathf.Clamp(Position.Y, 0, screenSize.Y)
        );

        if (velocity.X != 0)
            animatedSprite2D.Animation = "walk";
        else if (velocity.Y != 0)
            animatedSprite2D.Animation = "walk";
        else
            animatedSprite2D.Animation = "stand";

        LookAt(GetGlobalMousePosition());
    }

    public override void _Input(InputEvent input)
    {
        if (input.IsActionPressed("shoot"))
        {
            var error = EmitSignal(SignalName.Shoot, Rotation, Position);
        }
    }
}