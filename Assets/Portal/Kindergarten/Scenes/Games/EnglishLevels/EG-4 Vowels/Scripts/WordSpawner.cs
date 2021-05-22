using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSpawner : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI fillInWordText;
    [SerializeField] private GameObject image;
    [SerializeField] private List<string> words;
    [SerializeField] private List<string> wordsAns;
    [SerializeField] private List<Sprite> images;

    private void Start() {
        fillInWordText.text = words[0];
        image.GetComponent<SpriteRenderer>().sprite = images[0];
    }
}
