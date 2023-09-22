using UnityEngine;
using UnityEngine.UI;
using Managers;

namespace UI
{
    public class UIEnd : MonoBehaviour
    {
        [Header("Single UI data")]
        [SerializeField] private GameObject playerObject = null;
        [SerializeField] private Text playerScoreText = null;

        [Header("Multiplayer UI data")]
        [SerializeField] private Image winnerImage = null;
        [SerializeField] private Text winnerText = null;
        [SerializeField] private Sprite player1Winner = null;
        [SerializeField] private Sprite player2Winner = null;
        [SerializeField] private GameObject player1 = null;
        [SerializeField] private GameObject player2 = null;
        [SerializeField] private Text player1ScoreText = null;
        [SerializeField] private Text player2ScoreText = null;

        [Header("Settings panel")]
        [SerializeField] private GameObject settingsPanel = null;

        [Header("Scenes")]
        [SerializeField] private string menuSceneName = "";
        [SerializeField] private string gameSceneName = "";

        private void Start()
        {
            SetWinner();
        }

        /// <summary>
        /// Resets the game by loading the specified game scene.
        /// </summary>
        public void ResetGame()
        {
            LoaderManager.Instance.LoadScene(gameSceneName);
        }

        /// <summary>
        /// Toggles the visibility of the setting panel and adjusts the time scale accordingly.
        /// </summary>
        /// <param name="state">True to show the setting panel, false to hide it.</param>
        public void SettingPanel(bool state)
        {
            settingsPanel.SetActive(state);
            if (state)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        /// <summary>
        /// Loads the main menu scene.
        /// </summary>
        public void MainMenu()
        {
            LoaderManager.Instance.LoadScene(menuSceneName);
        }

        /// <summary>
        /// Sets the winner based on the game configuration and score statistics.
        /// </summary>
        private void SetWinner()
        {
            if (GameConfiguration.Instance.GetPlayers() == GameConfiguration.GAME_MODE.SINGLEPLAYER)
            {
                // Hide player objects and winner image in singleplayer mode
                player1.SetActive(false);
                player2.SetActive(false);
                winnerImage.gameObject.SetActive(false);
                playerScoreText.text = Stats.winnerScore.ToString();
            }
            else
            {
                playerObject.SetActive(false);

                //Draw
                if (Stats.winnerScore == Stats.loserScore)
                {
                    // Hide winner image and show text for draw
                    winnerImage.enabled = false;
                    winnerText.enabled = true;
                    player1ScoreText.text = Stats.winnerScore.ToString();
                    player2ScoreText.text = Stats.loserScore.ToString();
                }
                else
                {
                    winnerText.enabled = false;
                    switch (Stats.playerWinner)
                    {
                        //Player 1 wins
                        case Stats.side.LEFT:
                            winnerImage.sprite = player1Winner;
                            player1ScoreText.text = Stats.winnerScore.ToString();
                            player2ScoreText.text = Stats.loserScore.ToString();
                            break;

                        //Player 2 wins
                        case Stats.side.RIGHT:
                            winnerImage.sprite = player2Winner;
                            player2ScoreText.text = Stats.winnerScore.ToString();
                            player1ScoreText.text = Stats.loserScore.ToString();
                            break;
                    }
                }
            }
        }
    }
}