using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour {
    [SerializeField] List<AudioClip> audioClips;
    public char OriginalLetter = 'a';
    int correctAnswers = 4;
    private int correctClicks;
    private float timer;
    private bool isTimeRunning = true;
    public int totalClicks = 0;
    public int totalScore = 0;
    private AudioSource _audioSource;
    public static GameController Instance { get; private set; }
    private void Awake() {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        GenerateBoard();
        UpdateDisplayLetters();
    }

    public void GenerateBoard() {
        var clickables = FindObjectsOfType<ClickLetters>();
        List<char> charsList = new List<char>();
        for (int i = 0; i < correctAnswers; i++) {
            charsList.Add(OriginalLetter);
        }

        for (int i = correctAnswers; i < clickables.Length; i++) {
            var chosenLetter = ChooseLetters();
            charsList.Add(chosenLetter);
            
        }
        charsList = charsList.OrderBy(t => Random.Range(0, 10000)).ToList();
        
        for (int i = 0; i < charsList.Count; i++) {
            clickables[i].SetLetter(charsList[i]);
        }
        FindObjectOfType<RemainingCounter>().SetRemaining(correctAnswers - correctClicks);
    }

    private void Update() {
        if (isTimeRunning) {
            timer += Time.deltaTime;
        }
    }

    public char ChooseLetters() {
        int ranNum = Random.Range(0, 26);
        var randomLetter = (char)('a' + ranNum);
        while (randomLetter == OriginalLetter) {
            ranNum = Random.Range(0, 26);
            randomLetter = (char)('a' + ranNum);
        }
        return randomLetter;
    }

    internal void HandleCorrectLetterClick(bool uppercase) {
        AudioClip clip = audioClips.FirstOrDefault(t => t.name == OriginalLetter.ToString());
        _audioSource.PlayOneShot(clip);
        correctClicks++;
        totalScore++;
        totalClicks++;
        FindObjectOfType<RemainingCounter>().SetRemaining(correctAnswers - correctClicks);
        if(correctClicks >= (correctAnswers-1)) {
            // Setting original letter to the next letter basically resetting the board here
            if (OriginalLetter >= 'z') {
                isTimeRunning = false;
                Debug.Log("Timer: " +timer);
                PlayerPrefs.SetInt("gameLevelEng", 2);
                PlayerPrefs.Save();
                int marks = (int) Math.Round(CalculateMarks());
                SaveManager.Instance.SaveGameData("English", "Capital small letters", marks, timer.ToString(), 40, 1);
                SaveManager.Instance.UpdateExperiencePoints(40);
                SaveManager.Instance.SaveProgressData("English", "game", 1);
                SceneManager.LoadScene("English");
            }
            if (OriginalLetter < 'z') {
                OriginalLetter++;    
            }
            UpdateDisplayLetters();
            correctClicks = 0;
            GenerateBoard();
            
        }
    }

    private void UpdateDisplayLetters() {
        foreach (var displayLetter in FindObjectsOfType<DisplayLetter>()) {
            displayLetter.SetLetter(OriginalLetter);
        }
        
    }
    
    private float CalculateMarks() {
        float totalMarks = totalClicks;
        float obtainedMarks = totalScore;

        float result = (obtainedMarks / totalMarks) * 10;
        Debug.Log("Result: " + result);
        return result;
    }
}


