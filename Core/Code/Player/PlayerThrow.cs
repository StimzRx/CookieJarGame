using Godot;

/* File Name: PlayerThrow.cs
 * Date Modified: 10/5/2024
 * Author(s): Skillful
 * Description: This Script handles the 
 * how a player throws and item.
 */

public partial class PlayerThrow : Node
{
    #region Godot Behaviors:

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("DropItem"))
        {
            GD.Print("Item Drops");
        }
    }

    #endregion
}
