using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour {
    public static bool isPopupOpened = true;
    [SerializeField] private GameObject levelPopup;

    private void Start() {
        EnableLevelPopup();
    }

    public void EnableLevelPopup() {
        levelPopup.SetActive(true);
        Time.timeScale = 0f;
        isPopupOpened = true;
    }

    public void DisableLevelPopup() {
        levelPopup.SetActive(false);
        Time.timeScale = 1f;
        isPopupOpened = false;
    }
}
