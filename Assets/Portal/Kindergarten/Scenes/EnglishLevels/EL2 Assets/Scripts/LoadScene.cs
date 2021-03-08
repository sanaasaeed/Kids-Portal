using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;

    public static void LoadNextSceneWithoutLoading() {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        AsyncOperation operation =  SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void LoadFirstScene() {
        SceneManager.LoadScene(0);
    }
    public void LoadNextScene() {
        StartCoroutine(LoadSceneAsync());
    }
    public void quit(){
        Application.Quit();
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
}
