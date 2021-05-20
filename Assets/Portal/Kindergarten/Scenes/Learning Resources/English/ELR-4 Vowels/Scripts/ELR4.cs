using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ELR4 : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private GameObject boardSet;
    [SerializeField] private List<String> texts;
    [SerializeField] private List<Sprite> boardImages;
    [SerializeField] private List<AudioClip> audios;
    private AudioSource audioSrc;
    private int screenIndex = 0;
    private void Start() {
        audioSrc = GetComponent<AudioSource>();
        panelText.text = texts[screenIndex];
        boardSet.GetComponent<SpriteRenderer>().sprite = boardImages[screenIndex];
        screenIndex++;
        StartCoroutine(Wait(2f));
    }

    IEnumerator Wait(float noOfSeconds) {
        yield return new WaitForSeconds(noOfSeconds);
        ChangeScene();
    }

    void ChangeScene() {
        if (screenIndex < texts.Count && screenIndex < boardImages.Count) {
            panelText.text = texts[screenIndex];
            boardSet.GetComponent<SpriteRenderer>().sprite = boardImages[screenIndex];
            screenIndex++;
            StartCoroutine(Wait(3f));
        }
        else {
            // TODO: Win screen
        }
    }
}
