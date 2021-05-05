using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour {
    public AlphabetObjSpawner alphabetObjSpawner;
    [SerializeField] private GameObject alphabetPrefab;
    public static bool isStart = true;
    public static List<Sprite> alphabetList = new List<Sprite>();
    private GameObject alphabetsInPos;
    private Animator alphabetAnimator;
    private ActivitySound m_activitySound;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        alphabetObjSpawner = FindObjectOfType<AlphabetObjSpawner>();
        m_activitySound = FindObjectOfType<ActivitySound>();
       // for (int i = 0; i < 9; i++) {
            alphabetList = alphabetObjSpawner.ReturnAlphabetList();
            SetAlphabets(alphabetList);
            
            // }

    }

    public static void SetAlphabets(List<Sprite> alphabetList) {
        foreach (var alphabet in FindObjectsOfType<GameObject>()) {
            if (alphabet.name.Contains("Alphabet")) {
                alphabet.GetComponent<Animator>().enabled = false;
                alphabet.GetComponent<AudioSource>().enabled = false;
                alphabet.GetComponent<SpriteRenderer>().sprite = alphabetList[UnityEngine.Random.Range(0, alphabetList.Count)];
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
