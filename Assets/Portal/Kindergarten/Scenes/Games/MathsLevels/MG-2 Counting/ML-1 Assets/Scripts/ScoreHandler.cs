using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour {
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private int targetScore = 100;
    public int score;

    public void IncreaseScore() {
        score += 10;
        tmpText.text = score.ToString();
        if (score == targetScore) {
            SceneManager.LoadScene("MathsLevels"); // TODO: Add WIN screen
        }
    }

    public void DecreaseScore() {
        score -= 10;
        tmpText.text = score.ToString();
        if (score <= 0) {
            DynamicPlay.sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }
    }
}
