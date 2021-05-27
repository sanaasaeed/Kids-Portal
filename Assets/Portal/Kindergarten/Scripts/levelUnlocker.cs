using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUnlocker : MonoBehaviour {
    [SerializeField] public List<GameObject> lrLevelBtns;
    [SerializeField] public List<GameObject> gameLevelBtns;
    [SerializeField] private string lrPlayerPref;
    [SerializeField] private string gamePlayerPref;

    private void Start(){
        int currentLRLevel = PlayerPrefs.GetInt(lrPlayerPref, 0);
        int currentGameLevel = PlayerPrefs.GetInt(gamePlayerPref, 0);
        UnlockGame(currentLRLevel);
        if (currentGameLevel > 0) {
            UnlockLearningResource(currentGameLevel);
        }
    }
    public void UnlockGame(int currentLevel) {
        for (int i = 0; i < currentLevel; i++) {
            Debug.Log(currentLevel);
            Debug.Log("LR" + i);
            gameLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            gameLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void UnlockLearningResource(int currentLevel) {
        for (int i = 0; i <= currentLevel; i++) {
            Debug.Log("CURRENT LEVEL LR" + currentLevel);
            Debug.Log("Game: " + i);
            lrLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            lrLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
            /*lrLevelBtns[i].transform.GetChild(3).transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;*/
        }
    }

}
