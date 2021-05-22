using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSpawner : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI fillInWordText;
    [SerializeField] public GameObject image;
    [SerializeField] public List<string> words;
    [SerializeField] public List<string> wordsAns;
    [SerializeField] private List<Sprite> images;
    public static int indexNo = 0;

    private void Start() {
        DisplayTextAndImage();
    }

    public void DisplayTextAndImage() {
        fillInWordText.enabled = true;
        fillInWordText.text = words[indexNo];
        image.GetComponent<SpriteRenderer>().sprite = images[indexNo];
       // indexNo++;
    }
}
