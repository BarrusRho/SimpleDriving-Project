using UnityEngine;

namespace MobileGameDev.SimpleDriving
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private float _carSpeed;
        [SerializeField] private float _speedGain;

        private void Update()
        {
            _carSpeed += _speedGain * Time.deltaTime;

            transform.Translate(Vector3.forward * _carSpeed * Time.deltaTime);
        }
    }
}