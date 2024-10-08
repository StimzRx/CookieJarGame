using Godot;
using System;
using System.Threading.Tasks;

/* File Name: GameManager.cs
 * Date Modified: 10/5/2024
 * Author(s): Skillful
 * Description: This Script handles the 
 * state of the game.
 */

namespace CookieJar.Managers;
public partial class GameManager : Node
{
    #region Variables:

    [Export]
    private GameState _gameState;
    private bool _stateChanged;
    public static event Action<GameState> OnGameStateChanged;

    #endregion

    #region Enumerators:

    public enum GameState
    {
        Playing,
        GameOver
    }

    #endregion

    #region Public Behaviors:

    public async Task UpdateGameState(GameState newState)
    {
        _gameState = newState;

        switch (newState)
        {
            case GameState.Playing:
                GD.Print("In Playing State");
                break;
            case GameState.GameOver:
                GD.Print("In GameOver State");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
        await Task.Yield();
    }

    #endregion

}
