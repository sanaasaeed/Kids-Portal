using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetDestroyer : MonoBehaviour {
    private ActivitySound m_activitySound;
    private static int collectedALphabetCount = 0;
    private static int totalClicks = 0;
    private TweenPopup tweenPopup;
    

    private void Start() {
        m_activitySound = FindObjectOfType<ActivitySound>();
        tweenPopup = FindObjectOfType<TweenPopup>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_activitySound.selectedAlphabet.name)) {
            totalClicks++;
            Destroy(gameObject);
            collectedALphabetCount++;
            OnAlphabetsCollected();
        }
        else {
            totalClicks++;
            Debug.Log("Wrong alphabet selected ");
        }
    }
    public void OnAlphabetsCollected() {
        if (collectedALphabetCount == m_activitySound.count) {
            int percentage = CalculateMarks();
            Debug.Log(percentage);
            totalClicks = 0;
            collectedALphabetCount = 0;
            ActivityManager.isStart = false;
            if (percentage > 50) {
                tweenPopup.OpenPopup();
                StartCoroutine(ShowPopup("Activity Cleared. Good Work", 0.4f));
            } else {
                tweenPopup.OpenPopup();
                AlphabetObjSpawner.alphabetNo -= 4;
                StartCoroutine(ShowPopup("Try Reading Again", 0.4f));
            }
        }
    }

    public int CalculateMarks() {
        int percentage = (int) (0.5f + ((100f * collectedALphabetCount) / totalClicks));
        return percentage;
    }
    
    IEnumerator ShowPopup (string resultMsg, float delay) {
        tweenPopup.resultText.text = resultMsg;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("E-LR-1");
    }
}