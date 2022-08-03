using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MobileGameDev.SimpleDriving
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _highScoreText;

        private void Start()
        {
            int currentHighScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);

            _highScoreText.text = $"High Score: {currentHighScore}";
        }

        public void PlayGame()
        {
            SceneManager.LoadSceneAsync("Game");
        }
    }
}