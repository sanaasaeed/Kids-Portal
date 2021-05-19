using UnityEngine;
using UnityEngine.SceneManagement;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadNextScene() {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }

        public static void LoadFirstScene() {
            SceneManager.LoadScene(0);
        }

        public static void LoadLastScene() {
            SceneManager.LoadScene("Game Over");
        }

        public static void OnQuit() {
            Application.Quit();
        }
    }
}
