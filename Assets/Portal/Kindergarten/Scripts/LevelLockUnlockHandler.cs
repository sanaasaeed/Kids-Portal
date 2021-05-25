using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLockUnlockHandler : MonoBehaviour {
    [SerializeField] public List<GameObject> lrLevelBtns;
    [SerializeField] public List<GameObject> gameLevelBtns;

    private void Start(){
        int currentLRLevel = PlayerPrefs.GetInt("lrLevelEng", 0);
        int currentGameLevel = PlayerPrefs.GetInt("gameLevelEng", 0);
        UnlockGame(currentLRLevel - 1);
        UnlockLearningResource(currentGameLevel + 1);
    }
    public void UnlockGame(int currentLevel) {
        gameLevelBtns[currentLevel].GetComponent<AnimatedButton>().interactable = true;
        gameLevelBtns[currentLevel].transform.GetChild(3).gameObject.SetActive(false);
    }

    public void UnlockLearningResource(int currentLevel) {
        lrLevelBtns[currentLevel].GetComponent<AnimatedButton>().interactable = true;
        lrLevelBtns[currentLevel].transform.GetChild(3).gameObject.SetActive(false);
    }

}
