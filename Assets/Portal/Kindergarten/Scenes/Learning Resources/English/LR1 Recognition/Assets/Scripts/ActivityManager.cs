using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour {
    public AlphabetObjSpawner alphabetObjSpawner;
    [SerializeField] private GameObject alphabetPrefab;
    public static bool isStart = true;
    private GameObject alphabetsInPos;
    private Animator alphabetAnimator;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        alphabetObjSpawner = FindObjectOfType<AlphabetObjSpawner>(); 
       // for (int i = 0; i < 9; i++) {
            var alphabetList = alphabetObjSpawner.ReturnAlphabetList();
            PlayAlphabets(alphabetList);
       // }
        
    }

    public void PlayAlphabets(List<Sprite> alphabetList) {
        foreach (var alphabet in FindObjectsOfType<GameObject>()) {
            if (alphabet.name.Contains("Alphabet")) {
                alphabet.GetComponent<Animator>().enabled = false;
                alphabet.GetComponent<AudioSource>().enabled = false;
                alphabet.GetComponent<SpriteRenderer>().sprite = alphabetList[UnityEngine.Random.Range(0, alphabetList.Count)];
            }
        }
    }
    
    public void BackBtn() {
        isStart = false;
        SceneManager.LoadScene("E-LR-1");
    }
    
}
