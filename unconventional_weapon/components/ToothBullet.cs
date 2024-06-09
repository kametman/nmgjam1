using Godot;
using System;

public partial class ToothBullet : Area2D
{
	private float _toothSpeed = 500f;
	private Vector2 _toothDirection = Vector2.Zero;
	private float _toothSpin = 5f;

	private bool _isFlying, _isReturning;

	private Timer _flightTimer;

	public override void _Ready()
	{
		_flightTimer = GetNode<Timer>("FlightTimer");
		_isFlying = false;
		_isReturning = false;
	}

	public override void _Process(double delta)
	{
		if (_isFlying) { FlyTooth((float)delta); }
	}

	private void FlyTooth(float delta)
	{
		GlobalPosition += _toothDirection * _toothSpeed * delta;
		RotationDegrees += _toothSpin;
	}

	public void Init(Vector2 startPosition, Vector2 movePosition)
	{
		GlobalPosition = startPosition;
		_toothDirection = (movePosition - startPosition).Normalized();
		_isFlying = true;
		_flightTimer.Start();
	}

	public void OnFlightTimerTimeout()
	{
		_isFlying = false;
		Rotation = 0f;
	}
}
