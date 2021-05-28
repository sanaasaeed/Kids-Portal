using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MLR3 : MonoBehaviour {
    [SerializeField] private List<GameObject> shapesPrefab;
    [SerializeField] private TextMeshProUGUI shapeText;
    [SerializeField] private List<AudioClip> audios;
    private AudioSource audioSrc;
    public static int index = 0;
    public float levelTimer = 0;
    private bool isTimerRunning = true;

    private void Start() {
        audioSrc = GetComponent<AudioSource>();
        SetShape(index);
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
    }

    public void NextBtn() {
        RemoveClones();
        SetShape(index);
    }

    public void RepeatBtn() {
        RemoveClones();
        index--;
        GameObject currentPrefab = shapesPrefab[index];
        Instantiate(currentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        audioSrc.PlayOneShot(audios[index]);
        shapeText.text = currentPrefab.name;
        index++;
    }

    public void SetShape(int shapeIndex) {
        if (shapeIndex < shapesPrefab.Count) {
            GameObject currentPrefab = shapesPrefab[shapeIndex];
            Instantiate(currentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            audioSrc.PlayOneShot(audios[shapeIndex]);
            shapeText.text = currentPrefab.name;
            index++;
        }
        else {
            isTimerRunning = false;
            SceneManager.LoadScene("MLR-3Activity");
        }
    }

    void RemoveClones() {
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var clone in allClones) {
            if (clone.name.Contains("Clone")) {
                Destroy(clone);
            }
        }
    }
}
