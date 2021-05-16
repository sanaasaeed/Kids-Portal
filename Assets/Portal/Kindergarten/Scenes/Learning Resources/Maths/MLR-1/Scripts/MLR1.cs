using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class MLR1 : MonoBehaviour {
    [SerializeField] private List<Sprite> mathLetters;
    [SerializeField] private List<AudioClip> audios;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject sunflowerPrefab;
    private int letterNo = 0;
    private GameObject clone;
    private AudioSource letterAudioSource;
    void Start() {
        letterAudioSource = letterPrefab.GetComponent<AudioSource>();
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
        letterAudioSource.PlayOneShot(audios[letterNo]);
        for (int i = 0; i < Int32.Parse(mathLetters[0].name); i++) {
            clone = Instantiate(sunflowerPrefab, new Vector3(0, -2, -1), quaternion.identity);
        }
        letterNo++;
    }

    public void NextBtn() {
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[letterNo];
        letterAudioSource.PlayOneShot(audios[letterNo]);
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        for (int i = 0; i < Int32.Parse(mathLetters[letterNo].name); i++) {
            Instantiate(sunflowerPrefab, new Vector3(0+ i, -2, -1), quaternion.identity);
        }
        letterNo++;
    }
}
