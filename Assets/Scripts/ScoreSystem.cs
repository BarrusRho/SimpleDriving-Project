using UnityEngine;
using TMPro;

namespace MobileGameDev.SimpleDriving
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private int _scoreMultiplier;

        private float _score;

        private void Update()
        {
            _score += _scoreMultiplier * Time.deltaTime;

            _scoreText.text = Mathf.FloorToInt(_score).ToString();
        }
    }
}