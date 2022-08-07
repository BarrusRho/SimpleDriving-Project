using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

namespace MobileGameDev.SimpleDriving
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private NotificationHandler _notificationHandler;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _energyText;
        [SerializeField] private int _maxEnergy;
        [SerializeField] private int _energyRechargeDuration;

        private int _energy;

        private const string EnergyKey = "Energy";
        private const string EnergyRechargedKey = "EnergyRecharged";

        private void Start()
        {
            int currentHighScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);

            _highScoreText.text = $"High Score: {currentHighScore}";

            _energy = PlayerPrefs.GetInt(EnergyKey, _maxEnergy);

            if (_energy == 0)
            {
                string energyRechargedString = PlayerPrefs.GetString(EnergyRechargedKey, string.Empty);

                if (energyRechargedString == string.Empty)
                {
                    return;
                }

                DateTime energyRecharged = DateTime.Parse(energyRechargedString);

                if (DateTime.Now > energyRecharged)
                {
                    _energy = _maxEnergy;
                    PlayerPrefs.SetInt(EnergyKey, _maxEnergy);
                }
            }

            _energyText.text = $"Play ({_energy})";
        }

        public void PlayGame()
        {
            if (_energy < 1)
            {
                return;
            }

            _energy--;

            PlayerPrefs.SetInt(EnergyKey, _energy);

            if (_energy == 0)
            {
                DateTime energyRecharged = DateTime.Now.AddMinutes(_energyRechargeDuration);
                PlayerPrefs.SetString(EnergyRechargedKey, energyRecharged.ToString());
                _notificationHandler.ScheduleNotification(energyRecharged);
            }

            SceneManager.LoadSceneAsync("Game");
        }
    }
}