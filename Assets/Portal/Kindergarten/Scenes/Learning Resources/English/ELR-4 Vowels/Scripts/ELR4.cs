using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        audioSrc.PlayOneShot(audios[screenIndex]);
        screenIndex++;
    }

    public void NextBtn() {
        ChangeScene();
    }
    void ChangeScene() {
        if (screenIndex < texts.Count && screenIndex < boardImages.Count) {
            panelText.text = texts[screenIndex];
            boardSet.GetComponent<SpriteRenderer>().sprite = boardImages[screenIndex];
            audioSrc.PlayOneShot(audios[screenIndex]);
            screenIndex++;
        }
        else {
            SceneManager.LoadScene("ELR4Activity");
        }
    }
}
