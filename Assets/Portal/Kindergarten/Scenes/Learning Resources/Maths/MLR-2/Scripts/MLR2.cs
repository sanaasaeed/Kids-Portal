using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MLR2 : MonoBehaviour {
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject digit;
    [SerializeField] private List<Sprite> numbers;
    [SerializeField] private List<AudioClip> audios;
    [SerializeField] private AudioSource audioSrc;
    public static int letterNo = 0;
    private float lastEggPos = -6.8f;
    private GameObject clone;
    private int screenNo = 0;
    void Start() {
        audioSrc = GetComponent<AudioSource>();
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        audioSrc.PlayOneShot(audios[letterNo]);
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(lastEggPos, -3.5f, -1), quaternion.identity);
        }
        letterNo++;
    }

    public void NextBtn() {
        screenNo++;
        if (letterNo == 10) {
            SceneManager.LoadScene("MLR2Activity");
        }
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        audioSrc.PlayOneShot(audios[letterNo]);
        lastEggPos = -6.8f;
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(lastEggPos, -3.5f, -1), quaternion.identity);
            Debug.Log("Last Egg Position: " + lastEggPos);
            lastEggPos = lastEggPos + 1.5f;
        }
        letterNo++;
    }
    
}
