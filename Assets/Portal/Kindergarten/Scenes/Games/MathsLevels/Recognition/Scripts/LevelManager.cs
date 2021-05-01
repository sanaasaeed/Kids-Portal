using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {
    public static bool isPopupOpened = true;
    public static int levelNo = 1;
    public static int numberToGet;
    public static int score;
    [SerializeField] private GameObject levelPopup;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI randomNumber;
    [SerializeField] private TextMeshProUGUI scoreText;
        private void Start() {
        numberToGet = Random.Range(0, 9);
        randomNumber.text = numberToGet.ToString();
        levelText.text = "Level " + levelNo;
        scoreText.text = score.ToString();
        EnableLevelPopup();
        SetLevelVars();
    }
    private void SetLevelVars() {
        if (levelNo == 1) {
            PlayerCar.speed = 20f;
            NumberSpawner.gap = Random.Range(20, 40);
        } else if (levelNo == 2) {
            PlayerCar.speed = 25f;
            NumberSpawner.gap = Random.Range(20, 30);
        } else if (levelNo == 3) {
            PlayerCar.speed = 30f;
            NumberSpawner.gap = Random.Range(20, 25);
        }
    }

    public void EnableLevelPopup() {
        levelPopup.SetActive(true);
        Time.timeScale = 0f;
        isPopupOpened = true;
    }

    public void DisableLevelPopup() {
        levelPopup.SetActive(false);
        Time.timeScale = 1f;
        isPopupOpened = false;
    }

    public void IncreaseScore() {
        score += 10;
        if (score == 60) {
            levelNo = 2;
            SetLevelVars();
            EnableLevelPopup();
        } else if (score > 100) {
            levelNo = 3;
            SetLevelVars();
            EnableLevelPopup();
        }

        scoreText.text = score.ToString();
    }

    public void RestartLevel() {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
