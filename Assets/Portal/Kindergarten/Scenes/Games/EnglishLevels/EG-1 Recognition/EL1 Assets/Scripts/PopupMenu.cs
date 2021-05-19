using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupMenu : MonoBehaviour {
    public static bool IsPopUpOpened = true;
    public GameObject popupMenu;
    public TextMeshProUGUI goals;
    private GameState gameState;
    private void Start() {
        gameState = FindObjectOfType<GameState>();
        Time.timeScale = 0f;
        string alphabetTarget = GameState.target.ToString();
        alphabetTarget = alphabetTarget.Substring(0, 1);
        goals.text = $"Collect all {alphabetTarget} \nAvoid all other letters \nReach {GameState.levelScore} points";
        
    }

    public void Update() {
        
        if (Input.GetKeyDown(KeyCode.I)) {
            if (!IsPopUpOpened) {
                OpenPopUp();
            } 
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPopUpOpened) {
                ClosePopUp();
            }
        }
    }

    public void OpenPopUp() {
        popupMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPopUpOpened = true;
    }

    public void ClosePopUp() {
        popupMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPopUpOpened = false;
    }
}
