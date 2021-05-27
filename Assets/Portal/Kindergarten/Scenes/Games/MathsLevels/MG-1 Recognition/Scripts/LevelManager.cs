using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {
    public static bool isPopupOpened = true;
    public static int levelNo = 1;
    public static int numberToGet;
    public static int score;
    public static int indexHeart = 0;
    public static int totalLives = 4;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private GameObject levelPopup;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI randomNumber;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start() {
        numberToGet = Random.Range(0, 9);
        randomNumber.text = numberToGet.ToString();
        levelText.text = "Level " + levelNo;
        scoreText.text = score.ToString();
        SetLevelVars();
    }
    private void SetLevelVars() {
        if (levelNo == 1) {
            PlayerCar.speed = 20f;
            NumberSpawner.gap = Random.Range(20, 40);
        } else if (levelNo == 2) {
            numberToGet = Random.Range(0, 9);
            PlayerCar.speed = 25f;
            NumberSpawner.gap = Random.Range(20, 30);
        } else if (levelNo == 3) {
            numberToGet = Random.Range(0, 9);
            PlayerCar.speed = 35f;
            NumberSpawner.gap = Random.Range(20, 25);
        }else if (levelNo == 4) {
            numberToGet = Random.Range(0, 9);
            PlayerCar.speed = 40f;
            NumberSpawner.gap = Random.Range(20, 25);
        }
    }

    public void EnableLevelPopup() {
        randomNumber.text = numberToGet.ToString();
        levelText.text = "Level " + levelNo;
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
        if (score == 20) {
            levelNo = 2;
            SetLevelVars();
            EnableLevelPopup();
        } else if (score == 40) {
            levelNo = 3;
            numberToGet = Random.Range(0, 9);
            SetLevelVars();
            EnableLevelPopup();
        } else if (score == 60) {
            PlayerPrefs.SetInt("gameMathLevel", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Math");
        }
        scoreText.text = score.ToString();
    }

    public void DecreaseLives() {
        totalLives -= 1;
        if (totalLives < 1) {
            Debug.Log("GameOver");
            SceneManager.LoadScene("GameOver");
        }
        else {
            hearts[indexHeart].GetComponent<Image>().sprite = emptyHeart;
            indexHeart++;
        }
    }
}
