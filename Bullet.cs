using Godot;
using System;

public partial class Bullet : Area2D
{
    public Vector2 Velocity;

    [Export]
    public float Speed { get; set; } = 400;
    
    public override void _Ready()
    {
        Velocity = new Vector2(Speed, 0).Rotated(Rotation);
    }

    public override void _Process(double delta)
    {
        Position += Velocity * (float)delta;
    }
    
}
