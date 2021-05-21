using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShapeManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    private static int score = 0;
    public void IncreaseScore() {
        score += 10;
        scoreText.text = score.ToString();
    }

    public void DecreaseScore() {
        score -= 10;
        scoreText.text = score.ToString();
    }
}
