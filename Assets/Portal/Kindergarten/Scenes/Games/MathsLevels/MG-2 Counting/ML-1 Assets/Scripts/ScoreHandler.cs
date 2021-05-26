using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private int targetScore = 100;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Sprite heartEmpty;
    public int score;
    public int totalLives = 3;
    private int indexHeart = 0;

    public void IncreaseScore() {
        score += 10;
        tmpText.text = score.ToString();
        if (score == targetScore) {
            PlayerPrefs.SetInt("gameMathLevel", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Math");
        }
    }

    public void DecreaseScore() {
        /*score -= 10;
        tmpText.text = score.ToString();
        if (score <= 0) {
            DynamicPlay.sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("GameOver");
        }*/
        totalLives--;
        if (totalLives < 1) {
            SceneManager.LoadScene("GameOver");
        }
        else {
            hearts[indexHeart].GetComponent<Image>().sprite = heartEmpty;
            indexHeart++;
        }
    }
}
