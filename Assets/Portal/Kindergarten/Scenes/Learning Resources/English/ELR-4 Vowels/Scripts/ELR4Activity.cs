using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ELR4Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> consonants;
    [SerializeField] private List<Sprite> vowels;
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] public GameObject resultPanel;
    private List<int> vowelsChilds = new List<int>();
    private void Start() {
        SpawnAlphabets();
    }

    void SpawnVowels(int childNo, int i) {
        if (!vowelsChilds.Contains(childNo)) {
            alphabetPrefab.transform.GetChild(childNo).GetComponent<SpriteRenderer>().sprite = vowels[i];
            vowelsChilds.Add(childNo);
        }
        else {
            childNo = Random.Range(0, alphabetPrefab.transform.childCount);
            SpawnVowels(childNo, i);
        }
    }
    
    void SpawnAlphabets() {
        for (int i = 0; i < vowels.Count; i++) {
            int childNo = Random.Range(0, alphabetPrefab.transform.childCount);
            SpawnVowels(childNo, i);
        }
        
        for (int i = 0; i < alphabetPrefab.transform.childCount; i++) {
            if (!vowelsChilds.Contains(i)) {
                alphabetPrefab.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = consonants[Random.Range(0, consonants.Count)];
            }
            
        }
    }
}
