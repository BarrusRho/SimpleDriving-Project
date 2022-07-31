using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobileGameDev.SimpleDriving
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _carSpeed;
        [SerializeField] private float _speedGain;
        [SerializeField] private float _turnSpeed;

        private int _steerValue;

        private void Update()
        {
            _carSpeed += _speedGain * Time.deltaTime;

            transform.Rotate(0f, _steerValue * _turnSpeed * Time.deltaTime, 0f);

            transform.Translate(Vector3.forward * _carSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Obstacle") == true)
            {
                SceneManager.LoadSceneAsync("MainMenu");
            }
        }

        public void Steer(int value)
        {
            _steerValue = value;
        }
    }
}