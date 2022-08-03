using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobileGameDev.SimpleDriving
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync("Game");
        }
    }
}