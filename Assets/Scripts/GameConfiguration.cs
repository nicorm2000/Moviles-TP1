using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class GameConfiguration : MonoBehaviourSingleton<GameConfiguration>
{
    public enum GAME_MODE
    {
        SINGLEPLAYER,
        MULTIPLAYER
    }

    public enum GAME_DIFFICULT
    {
        EASY,
        MEDIUM,
        DIFFICULT
    }

    [Header("Buttons data")]
    [SerializeField] private Color unpressButton = Color.white;
    [SerializeField] private Color pressButton = Color.white;

    [Header("Configuration")]
    public GAME_MODE playersAmount;
    public GAME_DIFFICULT difficulty;

    private void Start()
    {
        playersAmount = GAME_MODE.SINGLEPLAYER;
        difficulty = GAME_DIFFICULT.EASY;
    }

    public GAME_MODE GetPlayers() => playersAmount;
    public GAME_DIFFICULT GetDifficulty() => difficulty;

    public void ChangeButtonColor(Button[] buttons, int index)
    {
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == index) buttons[i].image.color = pressButton;
                else buttons[i].image.color = unpressButton;
            }
        }
    }
    public void SetPlayers(int gameMode)
    {
        playersAmount = (GAME_MODE)gameMode;
    }

    public void SetDifficulty(int gameDifficult)
    {
        difficulty = (GAME_DIFFICULT)gameDifficult;
    }
}