using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ActivityManager : MonoBehaviour {
    public AlphabetObjSpawner alphabetObjSpawner;
    public static bool isStart = true;
    public static List<Sprite> alphabetList = new List<Sprite>();
    private GameObject m_alphabetsInPos;
    private ActivitySound m_activitySound;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        alphabetObjSpawner = FindObjectOfType<AlphabetObjSpawner>();
        m_activitySound = FindObjectOfType<ActivitySound>();
            alphabetList = alphabetObjSpawner.ReturnAlphabetList();
            SetAlphabets(alphabetList);
    }

    public void SetAlphabets(List<Sprite> alphabetList) {
        foreach (var alphabet in FindObjectsOfType<GameObject>()) {
            if (alphabet.name.Contains("Alphabet")) {
                alphabet.GetComponent<Animator>().enabled = false;
                alphabet.GetComponent<AudioSource>().enabled = false;
                Sprite randomSprite = alphabetList[Random.Range(0, alphabetList.Count)];
                alphabet.GetComponent<SpriteRenderer>().sprite = randomSprite;
            }
        }
    }

    private void OnMouseEnter() {
        Debug.Log("Mouse Entered");
    }

    public void BackBtn() {
        isStart = false;
        SceneManager.LoadScene("E-LR-1");
    }

    
    
}
