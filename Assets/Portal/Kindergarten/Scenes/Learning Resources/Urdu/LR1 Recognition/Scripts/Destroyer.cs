using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI goodbadText;
    [SerializeField] private GameObject panel;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            panel.SetActive(false);
        }
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == ULR1Activity.nextAlphabet) {
            Destroy(gameObject);
            goodbadText.text = "Excellent";
            panel.SetActive(true);
            SceneManager.LoadScene("ULR-1");
        }
        else {
            goodbadText.text = "Try Again";
            panel.SetActive(true);
        }
    }
}
