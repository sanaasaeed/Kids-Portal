using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI gameStatus;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI totalClicksText;
    [SerializeField] private TextMeshProUGUI correctText;
    

    public void SetStatus(string gameStatus, string score, string totalClicks, string correct) {
        this.gameStatus.text = gameStatus;
        yourScoreText.text = "Score: " + score;
        totalClicksText.text = "Total Clicks: " + totalClicks;
        correctText.text = "Correct: " + correct;
    }
}
