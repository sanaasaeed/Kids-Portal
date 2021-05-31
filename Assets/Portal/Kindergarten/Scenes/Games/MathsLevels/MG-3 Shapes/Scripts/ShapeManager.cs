using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class ShapeManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public GameObject randomShape;
    [SerializeField] public List<Sprite> shapes;
    [SerializeField] private GameObject panel;
    [SerializeField] private AudioClip wrongClip;
    [SerializeField] private AudioClip rightClip;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    private ResultPanel m_resultPanel;
    private AudioSource audioSrc;
    private int totalScore = 0;
    private int totalShoots = 0;
    private int correctClick = 0;
    private float leveltimer = 0;
    private bool isTimerRunning = true;
    [HideInInspector] public Sprite randmShapeSprite;
    private static int score = 0;
    
    private EnemySpawner enemySpawner;

    private void Start() {
        audioSrc = GetComponent<AudioSource>();
        enemySpawner = FindObjectOfType<EnemySpawner>(); ;
        randmShapeSprite = shapes[Random.Range(0, shapes.Count)];
        randomShape.GetComponent<Image>().sprite = randmShapeSprite;
        OpenPanel();
    }

    private void Update() {
        if (isTimerRunning) {
            leveltimer += Time.deltaTime;
        }
    }

    public void IncreaseScore() {
        totalShoots++;
        totalScore++;
        correctClick++;
        audioSrc.PlayOneShot(rightClip);
        score += 10;
        scoreText.text = score.ToString();
        if (score == 100) {
            isTimerRunning = false;
            Debug.Log("Level Timer" + leveltimer);
            // TODO: Win screen
            int marks = (int) Math.Round(CalculateMarks());
            if (marks > 5) {
                gameWinPanel.SetActive(true);
                Time.timeScale = 0f;
                m_resultPanel = FindObjectOfType<ResultPanel>();
                m_resultPanel.SetStatus("You Win", "Score: " + marks, "Total Shoots: " + totalShoots , "Correct Shoots: " + correctClick);
                SaveManager.Instance.UpdateExperiencePoints(40);
                SaveManager.Instance.SaveGameData("Maths", "Shapes", marks, leveltimer.ToString(), 40,1);
                SaveManager.Instance.SaveProgressData("Math", "game", 3);
            }
            else {
                gameOverPanel.SetActive(true);
                Time.timeScale = 0f;
                m_resultPanel = FindObjectOfType<ResultPanel>();
                m_resultPanel.SetStatus("Game Over", "Score: " + marks, "Total Shoots: " + totalShoots , "Correct Shoots: " + correctClick);
            }
        }
    }

    public void DecreaseScore() {
        totalScore--;
        totalShoots++;
        audioSrc.PlayOneShot(wrongClip);
        score -= 10;
        scoreText.text = score.ToString();
    }

    public void OpenPanel() {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel() {
        
        panel.LeanScale(Vector3.zero, 0.2f);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private float CalculateMarks() {
        float totalMarks = totalShoots;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
    
    public void TryAgain() {
        SceneManager.LoadScene("MG-3");
    }

    public void Back() {
        SceneManager.LoadScene("Math");
    }
}
