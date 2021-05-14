using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI RemarksText;
    [SerializeField] private GameObject panel;

    private void Start() {
        panel.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            panel.SetActive(false);
        }
    }

    private void OnMouseDown() {
        Debug.Log(ULR1Activity.nextAlphabet);
        if (gameObject.GetComponent<SpriteRenderer>().sprite == ULR1Activity.nextAlphabet) {
            Destroy(gameObject);
            RemarksText.text = "Excellent";
            panel.SetActive(true);
            SceneManager.LoadScene("ULR-1");
        }
        else {
            RemarksText.text = "Try Again";
            panel.SetActive(true);
        }
    }
}
