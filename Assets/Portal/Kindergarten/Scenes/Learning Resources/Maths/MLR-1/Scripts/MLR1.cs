using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MLR1 : MonoBehaviour {
    [SerializeField] public List<Sprite> mathLetters;
    [SerializeField] public List<AudioClip> audios;
    [SerializeField] private GameObject letterPrefab;
    public static int letterNo;
    public int endLetter = 0;
    private AudioSource letterAudioSource;
    private InputHandler inputHandlerScript;
    public static int screenNo = 0;
    public static int times = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        inputHandlerScript = GetComponent<InputHandler>();
        if (times > 0) {
            inputHandlerScript.panel.SetActive(false);
        }
        Debug.Log(times);
        times++;
        StartLearning();
    }

    public void StartLearning() {
        if (screenNo == 0) {
            letterNo = inputHandlerScript.@from;
            endLetter = inputHandlerScript.to;
            letterAudioSource = letterPrefab.GetComponent<AudioSource>();
            letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
            letterAudioSource.PlayOneShot(audios[letterNo]);
            letterNo++;
        }
        else {
            letterAudioSource = letterPrefab.GetComponent<AudioSource>();
            letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
            letterAudioSource.PlayOneShot(audios[letterNo]);
            letterNo++;
        }
    }

    public void NextBtn() {
        screenNo++;
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
        letterAudioSource.PlayOneShot(audios[letterNo]);
        if (screenNo % 3 == 0) {
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
