using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetDestroyer : MonoBehaviour {
    private ActivitySound m_activitySound;
    private static int collectedALphabetCount = 0;

    private void Start() {
        m_activitySound = FindObjectOfType<ActivitySound>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_activitySound.selectedAlphabet.name)) {
            Destroy(gameObject);
            collectedALphabetCount++;
            OnAlphabetsCollected();
        }
        else {
            // TODO: Deduct marks
            Debug.Log("Wrong alphabet selected ");
        }
        
    }
    public void OnAlphabetsCollected() {
        Debug.Log("Collect alphabet count: " + collectedALphabetCount);
        Debug.Log("Actvitiy sound " + m_activitySound.count);
        if (collectedALphabetCount == m_activitySound.count) {
            collectedALphabetCount = 0;
            ActivityManager.isStart = false;
            SceneManager.LoadScene("E-LR-1");
        }
        
    }
}
