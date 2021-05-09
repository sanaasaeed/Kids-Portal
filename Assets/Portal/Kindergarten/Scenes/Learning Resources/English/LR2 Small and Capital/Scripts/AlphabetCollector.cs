using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetCollector : MonoBehaviour {
    private EmbeddedActivity m_embeddedActivity;
    private static int correctAns;
    private void Start() {
        correctAns = 0;
        m_embeddedActivity = FindObjectOfType<EmbeddedActivity>();
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

        if (correctAns == 4) {
            GameRunner.alphabetNo = GameRunner.checkPoint;
            SceneManager.LoadScene("E-LR-2");
        }
    }
}
