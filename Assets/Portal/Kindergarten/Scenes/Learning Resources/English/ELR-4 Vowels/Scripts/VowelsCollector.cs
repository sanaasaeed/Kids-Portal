using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VowelsCollector : MonoBehaviour {
    public static int count = 0;
    public static int totalCount = 0;
    private ELR4Activity m_activity;
    private void Start() {
        m_activity = FindObjectOfType<ELR4Activity>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("A") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("E") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("I") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("O") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("U")) {
            count++;
            totalCount++;
            Destroy(gameObject);
        }
        else {
            totalCount++;
        }

        if (count > 20) {
            int percentage = CalculatePercentage();
            Debug.Log(percentage);
            if (percentage > 50) {
                Debug.Log("Game UNLOCKED");
            } else {
                m_activity.resultPanel.SetActive(true);
                StartCoroutine(SceneChange());
            }
            
        }
        else if (count % 5 == 0 && count != 0) {
            count++;
            Debug.Log(count);
            SceneManager.LoadScene("ELR4Activity");
        }
    }

    IEnumerator SceneChange() {
        yield return new WaitForSeconds(1f);
        m_activity.resultPanel.SetActive(false);
        Debug.Log("I m here");
        SceneManager.LoadScene("ELR4");
    }

    public int CalculatePercentage() {
        int percentage = (int) (0.5f + ((100f * count) / totalCount));
        return percentage;
    }
}
