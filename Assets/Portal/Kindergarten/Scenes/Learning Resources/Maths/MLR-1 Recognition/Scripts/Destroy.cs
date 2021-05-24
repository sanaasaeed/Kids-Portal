using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {
    private MLR1_Activity activityScript;
    private void Start() {
        activityScript = FindObjectOfType<MLR1_Activity>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == activityScript.randomSprite) {
            Destroy(gameObject);
            activityScript.cameraAudioSrc.PlayOneShot(activityScript.rightWrongAudios[0]);
            SceneManager.LoadScene("MLR-1");
        }
        else {
            activityScript.cameraAudioSrc.PlayOneShot(activityScript.rightWrongAudios[1]);
        }
    }
}
