using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour {
    [SerializeField] private GameObject gameManager;
    [SerializeField] private TMP_Text buttonText;
    private RandomSelection randomSelection;
    void Start() {
        randomSelection = gameManager.GetComponent<RandomSelection>();
        HandleClick();
    }

    public void HandleClick() {
        int noOfThings = randomSelection.noOfThings;
        if (buttonText.text == noOfThings.ToString()) {
            randomSelection.DestroyItems();
            randomSelection.DisplayThings();
        }
    }
}
