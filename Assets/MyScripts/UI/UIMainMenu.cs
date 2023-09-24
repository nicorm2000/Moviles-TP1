using UnityEngine;
using UnityEngine.UI;
using Managers;

public class UIMainMenu : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private string creditsSceneName = "";
    [SerializeField] private string gameSceneName = "";

    [Header("Groups")]
    [SerializeField] private GameObject menu = null;
    [SerializeField] private GameObject configuration = null;

    [Header("Players")]
    [SerializeField] private Button[] playersButtons = null;

    [Header("Difficulty")]
    [SerializeField] private Button[] difficultyButtons = null;

    private void Start()
    {
        GameConfiguration.Instance.ChangeButtonColor(playersButtons, (int)GameConfiguration.Instance.playersAmount);
        GameConfiguration.Instance.ChangeButtonColor(difficultyButtons, (int)GameConfiguration.Instance.difficulty);
    }

    public void SetMenu()
    {
        menu.SetActive(true);
        configuration.SetActive(false);
    }

    public void SetConfiguration()
    {
        menu.SetActive(false);
        configuration.SetActive(true);
    }

    public void SetPlayers(int gameMode)
    {
        GameConfiguration.Instance.SetPlayers(gameMode);
        GameConfiguration.Instance.ChangeButtonColor(playersButtons, (int)GameConfiguration.Instance.playersAmount);
    }

    public void SetDifficulty(int gameDifficult)
    {
        GameConfiguration.Instance.SetDifficulty(gameDifficult);
        GameConfiguration.Instance.ChangeButtonColor(difficultyButtons, (int)GameConfiguration.Instance.difficulty);
    }

    public void Game()
    {
        LoaderManager.Instance.LoadScene(gameSceneName);
    }

    public void Credits()
    {
        LoaderManager.Instance.LoadScene(creditsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}