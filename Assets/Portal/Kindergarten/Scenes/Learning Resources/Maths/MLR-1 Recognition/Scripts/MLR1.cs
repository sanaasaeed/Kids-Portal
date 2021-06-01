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
    [SerializeField] private List<string> numbersName;
    [SerializeField] private TextMeshProUGUI numberText;
    public static int letterNo = 0;
    public static int endLetter = 20;
    private AudioSource letterAudioSource;
    public static int screenNo = 0;
    public static int times = 0;
    private float levelTimer = 0;
    private bool isTimerRunning = true;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        /*inputHandlerScript = GetComponent<InputHandler>();
        if (times > 0) {
            inputHandlerScript.panel.SetActive(false);
        }*/
        Debug.Log(times);
        times++;
        StartLearning();
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
    }

    public void StartLearning() {
        if (screenNo == 0) {
            /*letterNo = inputHandlerScript.@from;
            endLetter = inputHandlerScript.to;*/
            letterAudioSource = letterPrefab.GetComponent<AudioSource>();
            letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
            numberText.text = numbersName[letterNo];
            letterAudioSource.PlayOneShot(audios[letterNo]);
            letterNo++;
        }
        else {
            letterAudioSource = letterPrefab.GetComponent<AudioSource>();
            letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
            numberText.text = numbersName[letterNo];
            letterAudioSource.PlayOneShot(audios[letterNo]);
            letterNo++;
        }
    }

    public void NextBtn() {
        if (letterNo <= endLetter) {
            screenNo++;
            letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
            numberText.text = numbersName[letterNo];
            letterAudioSource.PlayOneShot(audios[letterNo]);
            if (screenNo % 3 == 0) {
                SceneManager.LoadScene("MLR1_Activity");
            }
            letterNo++;
        }
        else {
            Debug.Log("You did great");
            isTimerRunning = false;
            PlayerPrefs.SetInt("lrMathLevel", 1);
            PlayerPrefs.Save();
            SaveManager.Instance.SaveLRData("Maths", "Number Recognition", 1,levelTimer.ToString());
            SaveManager.Instance.SaveProgressData("Math", "lr", 1);
            SceneManager.LoadScene("Math");
        }
    }

    public void RepeatBtn() {
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo-1];
        numberText.text = numbersName[letterNo - 1];
        letterAudioSource.PlayOneShot(audios[letterNo-1]);
    }
}
