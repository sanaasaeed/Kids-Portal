using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameState : MonoBehaviour{
    private Animator basketAnimation;
    [SerializeField] private GameObject targetAlphabetPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private List<Sprite> alphabets;
    private int count = 0;
    private int totalLives = 11;
    private static int totalScore = 0;
    private static int totalAlphabetsCollected = 0;
    private int level1score = 20;
    private int level2score = 20;
    private int level3score = 20;
    public static Sprite target;
    public static int levelScore;
    public static float timer = 0;
    public static bool isTimerRunning = true;

    private void OnEnable() {
        SetTargetAlphabet();
        SetLevelScore(level1score, level2score, level3score);
    }

    void Start() {
        basketAnimation = FindObjectOfType<Animator>();
    }

    private void Update() {
        if (isTimerRunning) {
            timer += Time.deltaTime;
        }
    }

    public void SetTargetAlphabet() {
        target = alphabets[Random.Range(0, 25)];
        targetAlphabetPrefab.GetComponent<SpriteRenderer>().sprite = target;
    }

    public void AnimateBasket() {
        basketAnimation.enabled = true;
    }

    public void StopAnimation() {
        basketAnimation.enabled = false;
    }

    public void IncreaseScore() {
        totalAlphabetsCollected++;
        totalScore++;
        Debug.Log(totalScore);
        count += 10;
        if (count == levelScore) {
            if (SceneManager.GetActiveScene().name != "EL1-3") {
                SceneLoader.LoadNextSceneWithoutLoading();
            }
            else {
                int marksToSend = (int)Math.Round(CalculateMarks());
               // DynamicPlay.sceneName = SceneManager.GetActiveScene().name;
               isTimerRunning = false;
               PlayerPrefs.SetInt("gameLevelEng", 1);
               PlayerPrefs.Save();
               SaveManager.Instance.SaveGameData("English", "AlphabetRecognition", marksToSend,timer.ToString(), 40,1);
               SaveManager.Instance.SaveProgressData("English", "game", 1);
               SceneManager.LoadScene("English");
            }
        }

        scoreText.text = count.ToString();
    }

    public void DecreaseScore() {
        totalAlphabetsCollected++;
        totalScore--;
        Debug.Log(totalScore);
    }

    public void SetLevelScore(int level1score, int level2score, int level3score) {
        if (SceneManager.GetActiveScene().name == "EL1-1") {
            levelScore = level1score;
        }

        if (SceneManager.GetActiveScene().name == "EL1-2") {
            levelScore = level2score;
        }

        if (SceneManager.GetActiveScene().name == "EL1-3") {
            levelScore = level3score;
        }
    }

    private float CalculateMarks() {
        float totalMarks = totalAlphabetsCollected;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
}
