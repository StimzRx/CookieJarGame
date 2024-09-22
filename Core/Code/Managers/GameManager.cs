using Godot;

namespace CookieJar.Managers;

public partial class GameManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			if (Input.MouseMode != Input.MouseModeEnum.Visible)
			{
				Input.SetMouseMode(Input.MouseModeEnum.Visible);
			}
			else
			{
				Input.SetMouseMode(Input.MouseModeEnum.Captured);
			}
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			Vector2 tmpPos = Hand.GlobalPosition;
			tmpPos.X += eventMouseMotion.Relative.X;

			float halfHandSize = HandSize.X / 2f;
			
			if (tmpPos.X < JarMinPos.GlobalPosition.X + halfHandSize)
				tmpPos.X = JarMinPos.GlobalPosition.X + halfHandSize;
			if(tmpPos.X > JarMaxPos.GlobalPosition.X - halfHandSize)
				tmpPos.X = JarMaxPos.GlobalPosition.X - halfHandSize;
			
			Hand.GlobalPosition = tmpPos;
		}
		
		base._UnhandledInput(@event);
	}

	[Export]
	public CharacterBody2D Hand { get; private set; }
	
	[Export]
	public Vector2 HandSize { get; private set; }

	[Export]
	public Marker2D JarMinPos { get; private set; }

	[Export]
	public Marker2D JarMaxPos { get; private set; }
}
