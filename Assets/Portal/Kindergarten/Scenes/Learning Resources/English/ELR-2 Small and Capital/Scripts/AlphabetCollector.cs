using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetCollector : MonoBehaviour {
    private EmbeddedActivity m_embeddedActivity;
    private static int correctAns;
    public static int totalClicks;
    private TweenPanel tweenPanel;
    private void Start() {
        correctAns = 0;
        totalClicks = 0;
        m_embeddedActivity = FindObjectOfType<EmbeddedActivity>();
        tweenPanel = FindObjectOfType<TweenPanel>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList1[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower()) && gameObject.CompareTag("row1")) {
            correctAns++;
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList2[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower()) && gameObject.CompareTag("row2")) {
            correctAns++;
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList3[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower()) && gameObject.CompareTag("row3")) {
            correctAns++;
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList4[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower()) && gameObject.CompareTag("row4")) {
            correctAns++;
            Destroy(gameObject);
        }

        totalClicks++;

        if (correctAns == GameRunner.interval) {
            int percentage = CalculateMarks();
            Debug.Log(percentage);
            if (percentage > 50) {
                GameRunner.alphabetNo = GameRunner.checkPoint;
                tweenPanel.OpenPanel();
                tweenPanel.resultText.text = "Activity Done. Good Work";
                SceneManager.LoadScene("ELR-2");
            }
            else {
                GameRunner.alphabetNo = GameRunner.checkPoint - GameRunner.interval;
                tweenPanel.resultText.text = "Activity Not completed. Repeat Again";
                SceneManager.LoadScene("ELR-2");
            }
            
        }
    }

    public int CalculateMarks() {
        int percentage = (int) (0.5f + ((100f * correctAns) / totalClicks));
        return percentage;
    }

    /*IEnumerator ShowPanel(string resultMsg, float delay) {
        tweenPanel.resultText.text = resultMsg;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("E-LR-2");
    } */
}
