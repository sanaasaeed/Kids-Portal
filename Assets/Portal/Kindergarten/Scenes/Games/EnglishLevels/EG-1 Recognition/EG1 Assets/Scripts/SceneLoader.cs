using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
    public GameObject loadingScreen;

    public Slider slider;
    // public void LoadNextScene() {
    //     int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentBuildIndex + 1);
    // }
    public static void LoadNextSceneWithoutLoading() {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation operation =  SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void LoadFirstScene() {
        SceneManager.LoadScene(0);
    }

    public static void LoadLastScene() {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void LoadLevelsScene() {
        SceneManager.LoadScene("English");
    }
    public void LoadNextScene() {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation operation =  SceneManager.LoadSceneAsync(currentSceneIndex + 1);
        loadingScreen.SetActive(true);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void OnQuit() {
        Application.Quit();
    }
}
