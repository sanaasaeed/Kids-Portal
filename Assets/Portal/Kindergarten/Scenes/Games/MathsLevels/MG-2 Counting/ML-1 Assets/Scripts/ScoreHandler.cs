using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private int targetScore = 180;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Sprite heartEmpty;
    [SerializeField] private GameObject gameverPanel;
    [SerializeField] private GameObject wonPanel;
    public int score = 0;
    private int totalScore = 0;
    private int totalClicks = 0;
    private float timer = 0;
    private bool isTimeRunning = true;
    private int correctClicks = 0;
    private int indexHeart = 0;
    private ResultPanel m_resultPanel;
    

    private void Update() {
        if (isTimeRunning) {
            timer += Time.deltaTime;
        }
    }

    public void IncreaseScore() {
        totalClicks++;
        correctClicks++;
        totalScore++;
        score += 10;
        tmpText.text = score.ToString();
        if (score == targetScore) {
            isTimeRunning = false;
            int marks = (int) Math.Round(CalculateMarks());
            if (marks > 5) {
                PlayerPrefs.SetInt("gameMathLevel", 2);
                PlayerPrefs.Save();
                wonPanel.SetActive(true);
                m_resultPanel = FindObjectOfType<ResultPanel>();
                Debug.Log("Marks " + marks);
                Debug.Log("Total " + totalClicks);
                Debug.Log("Correct " + correctClicks);
                m_resultPanel.SetStatus("You Won", marks.ToString(), totalClicks.ToString(), correctClicks.ToString()); 
                SaveManager.Instance.SaveGameData("English", "Counting", marks,timer.ToString(),40,1);
            }
            else {
                gameverPanel.SetActive(true);
                m_resultPanel = FindObjectOfType<ResultPanel>();
                m_resultPanel.SetStatus("Game Over", marks.ToString(), totalClicks.ToString(), correctClicks.ToString
                ());
            }
        }
    }

    public void TryAgain() {
        SceneManager.LoadScene("MG-2");
    }

    public void Back() {
        SceneManager.LoadScene("Math");
    }

    public void DecreaseScore() {
        totalClicks++;
        totalScore--;
    }
    
    private float CalculateMarks() {
        float totalMarks = totalClicks;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
}
