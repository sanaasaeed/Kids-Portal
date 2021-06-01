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
    [SerializeField] private GameObject levelPopup;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI randomNumber;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    private ResultPanel m_resultPanel;
    public static float timer = 0;
    private int correctCollected = 0;
    public static bool isTimerRunning = true;
    public static int totalScore = 0;
    public static int totalNumbersCollected = 0;
    private void Start() {
        numberToGet = Random.Range(0, 9);
        randomNumber.text = numberToGet.ToString();
        levelText.text = "Level " + levelNo;
        scoreText.text = score.ToString();
        SetLevelVars();
    }

    private void Update() {
        if (isTimerRunning) {
            timer += Time.deltaTime;
        }
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
        correctCollected++;
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
            isTimerRunning = false;
            int marks = (int) Math.Round(CalculateMarks());
            if (marks > 5) {
                gameWinPanel.SetActive(true);
                m_resultPanel = FindObjectOfType<ResultPanel>();
                Time.timeScale = 0f;
                m_resultPanel.SetStatus("Game Won", "Score: " + marks, "Total numbers collected: " + totalNumbersCollected, "Correct collected: " + correctCollected);
                PlayerPrefs.SetInt("gameMathLevel", 1);
                PlayerPrefs.Save();
                SaveManager.Instance.SaveGameData("Maths", "Number Recognition", marks,timer.ToString(),40,1);
                SaveManager.Instance.SaveProgressData("Math", "game", 1);
            }
            else {
                gameOverPanel.SetActive(true);
                m_resultPanel = FindObjectOfType<ResultPanel>();
                m_resultPanel.SetStatus("Game Over", "Score: " + marks, "Total numbers collected: " + totalNumbersCollected, "Correct collected: " + correctCollected);
                Time.timeScale = 0f;
            }
            
        }
        scoreText.text = score.ToString();
    }

    public void DecreaseScore() {
        score -= 10;
        totalNumbersCollected++;
        totalScore--;
        scoreText.text = score.ToString();
    }
    
    private float CalculateMarks() {
        float totalMarks = totalNumbersCollected;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
    
    public void TryAgain() {
        SceneManager.LoadScene("MG-1");
    }

    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Math");
    }
}
