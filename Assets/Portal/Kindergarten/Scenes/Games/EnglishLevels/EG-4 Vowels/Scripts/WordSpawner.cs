using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordSpawner : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI fillInWordText;
    [SerializeField] public GameObject image;
    [SerializeField] public List<string> words;
    [SerializeField] public List<string> wordsAns;
    [SerializeField] private List<Sprite> images;
    public int totalScore = 0;
    public int totalBulletsHit = 0;
    private float levelTimer = 0;
    private bool isTimerRunning = true;
    public static int indexNo = 0;

    private void Start() {
        DisplayTextAndImage();
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
    }

    public void DisplayTextAndImage() {
        if (indexNo < words.Count) {
            fillInWordText.enabled = true;
            fillInWordText.text = words[indexNo];
            image.GetComponent<SpriteRenderer>().sprite = images[indexNo]; 
        }
        else {
            isTimerRunning = false;
            int marks = (int) Math.Round(CalculateMarks());
           // PlayerPrefs.SetInt("", );
            SaveManager.Instance.SaveGameData("English", "Vowels", marks, levelTimer.ToString(),40,1);
            SaveManager.Instance.UpdateExperiencePoints(40);
            SceneManager.LoadScene("English");
        }
    }
    
    private float CalculateMarks() {
        float totalMarks = totalBulletsHit;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
}
