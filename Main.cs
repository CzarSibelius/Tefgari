using Godot;
using System;

public partial class Main : Node
{
    private PackedScene _bullet = GD.Load<PackedScene>("res://bullet.tscn");
    
    public void OnPlayerShoot(float rotation, Vector2 position)
    {
        GD.Print($"{nameof(OnPlayerShoot)}: {rotation} {position}");
        var bulletInstance = (Bullet)_bullet.Instantiate();
        AddChild(bulletInstance);
        bulletInstance.Rotation = rotation;
        bulletInstance.Position = position;
        bulletInstance.Velocity = new Vector2(400, 0).Rotated(rotation);
    }
}
