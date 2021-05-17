﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {
    private MLR1_Activity activityScript;
    private InputHandler inputHandler;
    private void Start() {
        activityScript = FindObjectOfType<MLR1_Activity>();
        inputHandler = FindObjectOfType<InputHandler>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == activityScript.randomSprite) {
            Destroy(gameObject);
            SceneManager.LoadScene("MLR-1");
        }
    }
}