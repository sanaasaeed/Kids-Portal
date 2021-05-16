using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MLR1 : MonoBehaviour {
    [SerializeField] private List<Sprite> mathLetters;
    [SerializeField] private List<AudioClip> audios;
    [SerializeField] private GameObject letterPrefab;
    public static int letterNo;
    public int endLetter = 0;
    private AudioSource letterAudioSource;
    private InputHandler inputHandlerScript;
    public static int screenNo;

    private void Start() {
        inputHandlerScript = GetComponent<InputHandler>();
    }

    public void StartLearning() {
        letterNo = inputHandlerScript.@from;
        endLetter = inputHandlerScript.to;
        Debug.Log(letterNo);
        letterAudioSource = letterPrefab.GetComponent<AudioSource>();
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
        letterAudioSource.PlayOneShot(audios[letterNo]);
        /*for (int i = 0; i < Int32.Parse(mathLetters[0].name); i++) {
            clone = Instantiate(sunflowerPrefab, new Vector3(0, -2, -1), quaternion.identity);
        }*/
        letterNo++;
    }

    public void NextBtn() {
        screenNo++;
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
        letterAudioSource.PlayOneShot(audios[letterNo]);
        if (screenNo % 5 == 0) {
           SceneManager.LoadScene("MLR1_Activity");
        }
        letterNo++;
        
    }

    public void RepeatBtn() {
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo-1];
        letterAudioSource.PlayOneShot(audios[letterNo-1]);
        /*var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        for (int i = 0; i < Int32.Parse(mathLetters[letterNo-1].name); i++) {
            Instantiate(sunflowerPrefab, new Vector3(0+ i, -2, -1), quaternion.identity);
        }*/
    }
}
