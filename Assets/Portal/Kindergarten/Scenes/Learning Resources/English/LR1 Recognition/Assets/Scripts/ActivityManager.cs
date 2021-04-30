using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour {
    public AlphabetObjSpawner alphabetObjSpawner;
    public static bool isStart = true;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        alphabetObjSpawner = FindObjectOfType<AlphabetObjSpawner>();
        alphabetObjSpawner.PlayActivity();
    }
    
    public void BackBtn() {
        isStart = false;
        SceneManager.LoadScene("E-LR-1");
    }
    
}
