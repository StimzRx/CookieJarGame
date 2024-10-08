using Godot;
/* File Name: PlayerManager.cs
 * Date Modified: 10/5/2024
 * Author(s): Stimz, Skillful
 * Description: This Script handles the 
 * player node and all of their actions
 * and how it interacts with other scenes.
 */
public partial class PlayerManager : Node
{
    #region Variables:

    [Export] public Marker2D JarMinPos;
    [Export] public Marker2D JarMaxPos;
    public CharacterBody2D CharacterBody2D { get; private set; }

    #endregion

    #region Godot Behaviors:

    public override void _EnterTree()
    {
        CharacterBody2D = GetNode<CharacterBody2D>("./HandCharacter");
    }

    #endregion
}
