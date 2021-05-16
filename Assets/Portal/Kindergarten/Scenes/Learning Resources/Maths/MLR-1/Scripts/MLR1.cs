﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MLR1 : MonoBehaviour {
    [SerializeField] private List<Sprite> mathLetters;
    [SerializeField] private List<AudioClip> audios;
    [SerializeField] private GameObject letterPrefab;
    public static int letterNo = 0;
    private AudioSource letterAudioSource;
    public static int screenNo = 0;
    void Start() {
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
        /*var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        for (int i = 0; i < Int32.Parse(mathLetters[letterNo].name); i++) {
            Instantiate(sunflowerPrefab, new Vector3(0+ i, -2, -1), quaternion.identity);
        }*/
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
