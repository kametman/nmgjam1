using Godot;
using System;

namespace UnconventionalWeapon.Components;

public partial class SkellyPlayer : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private Sprite2D _skullSprite;

	public override void _Ready()
	{
		_skullSprite = GetNode<Sprite2D>("SkullSprite");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("player_left", "player_right", "player_up", "player_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;

			_skullSprite.Frame = velocity.X > 0 ? 0 : velocity.X < 0 ? 1 : _skullSprite.Frame;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
