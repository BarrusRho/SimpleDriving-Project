using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

namespace MobileGameDev.SimpleDriving
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private NotificationHandler _notificationHandler;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _energyText;
        [SerializeField] private Button _playButton;
        [SerializeField] private int _maxEnergy;
        [SerializeField] private int _energyRechargeDuration;

        private int _energy;

        private const string EnergyKey = "Energy";
        private const string EnergyRechargedKey = "EnergyRecharged";

        private void Start()
        {
            OnApplicationFocus(true);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) { return;}

            CancelInvoke();

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
                else
                {
                    _playButton.interactable = false;
                    Invoke((nameof(EnergyRecharged)), (energyRecharged - DateTime.Now).Seconds);
                }
            }

            _energyText.text = $"Play ({_energy})";
        }

        private void EnergyRecharged()
        {
            _playButton.interactable = true;
            _energy = _maxEnergy;
            PlayerPrefs.SetInt(EnergyKey, _maxEnergy);
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

#if UNITY_ANDROID
                _notificationHandler.ScheduleNotification(energyRecharged);
#endif
            }

            SceneManager.LoadSceneAsync("Game");
        }
    }
}