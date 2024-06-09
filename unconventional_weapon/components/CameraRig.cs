using Godot;
using System;

public partial class CameraRig : Node2D
{
	private float _cameraZoom = 1f;
	[Export]public float CameraZoom
	{
		get { return _cameraZoom; }
		set 
		{
			_cameraZoom = value;
			UpdateCameraZoom();
		}
	}

	[Export]private Camera2D _mainCamera;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	private void UpdateCameraZoom()
	{
		if (_mainCamera == null) { return; }
		_mainCamera.Zoom = Vector2.One * _cameraZoom;
	}
}
