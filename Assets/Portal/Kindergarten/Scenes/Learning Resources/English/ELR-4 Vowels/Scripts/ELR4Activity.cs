using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ELR4Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> consonants;
    [SerializeField] private List<Sprite> vowels;
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] private List<float> xPos;
    [SerializeField] private List<float> yPos;
    private List<int> vowelsChilds = new List<int>();
    private void Start() {
        SpawnAlphabets();
    }

    void SpawnAlphabets() {
        for (int i = 0; i < vowels.Count; i++) {
            int childNo = Random.Range(0, alphabetPrefab.transform.childCount);
            vowelsChilds.Add(childNo);
            alphabetPrefab.transform.GetChild(childNo).GetComponent<SpriteRenderer>().sprite = vowels[i];
        }
        
        for (int i = 0; i < alphabetPrefab.transform.childCount; i++) {
            foreach (var vowelsChild in vowelsChilds) {
                if (i != vowelsChild) {
                    alphabetPrefab.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = consonants[Random.Range(0, consonants.Count)];
                }
            }
            
        }
    }
}
