using Godot;

// Ignore Spelling: Unhandled

/* File Name: PlayerMovement.cs
 * Date Modified: 10/5/2024
 * Author(s): Stimz, Skillful
 * Description: This Script handles the 
 * player node and how it moves.
 */

public partial class PlayerMovement : Node
{
    #region Variables:

    private PlayerManager _manager;
    private CharacterBody2D _hand;
    private Vector2 _handSize;
    private Marker2D _jarMinPos;
    private Marker2D _jarMaxPos;

    #endregion

    #region Godot Behaviors:

    public override void _EnterTree()
    {
        _manager = GetParent<PlayerManager>();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;

        _hand = _manager.CharacterBody2D;
        _handSize = _hand.Scale;
        _jarMaxPos = _manager.JarMaxPos;
        _jarMinPos = _manager.JarMinPos;     
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
            Vector2 tmpPos = _hand.GlobalPosition;
            tmpPos.X += eventMouseMotion.Relative.X;

            float halfHandSize = _handSize.X / 2f;

            // clamp the player to the jar's edges(min/max)
            if (tmpPos.X < _jarMinPos.GlobalPosition.X + halfHandSize)
                tmpPos.X = _jarMinPos.GlobalPosition.X + halfHandSize;
            if (tmpPos.X > _jarMaxPos.GlobalPosition.X - halfHandSize)
                tmpPos.X = _jarMaxPos.GlobalPosition.X - halfHandSize;

            _hand.GlobalPosition = tmpPos;
        }

        base._UnhandledInput(@event);
    }

    #endregion
}
