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
    public float levelTimer = 0;
    public bool isTimerRunning = true;
    private void Start() {
        audioSrc = GetComponent<AudioSource>();
        panelText.text = texts[screenIndex];
        boardSet.GetComponent<SpriteRenderer>().sprite = boardImages[screenIndex];
        audioSrc.PlayOneShot(audios[screenIndex]);
        screenIndex++;
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
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
            isTimerRunning = false;
            SceneManager.LoadScene("ELR4Activity");
        }
    }
}
