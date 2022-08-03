using UnityEngine;
using TMPro;

namespace MobileGameDev.SimpleDriving
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private int _scoreMultiplier;

        private float _score;

        public const string HighScoreKey = "HighScore";

        private void Update()
        {
            _score += _scoreMultiplier * Time.deltaTime;

            _scoreText.text = Mathf.FloorToInt(_score).ToString();
        }

        private void OnDestroy()
        {
            int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

            if (_score > currentHighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(_score));
            }
        }
    }
}