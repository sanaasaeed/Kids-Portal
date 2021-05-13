using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1 : MonoBehaviour {
    [SerializeField] private List<Sprite> urduAlphabetsSprite;
    [SerializeField] private GameObject alphabetContainer;
    private GameObject clone;
    public static int alphabetNo = 0;
    private int totalScrens = 13;
    private int screenNo = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (alphabetNo == 0) {
            SetChild(0, alphabetNo);
            for (int i = 1; i < 3; i++) {
                SetChild(i, alphabetNo + 1);
                alphabetNo++;
            }
            clone =  Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
            screenNo++;
        }
        else {
            for (int i = 0; i < 3; i++) {
                SetChild(i, alphabetNo + 1);
                alphabetNo++;
            }
            clone =  Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
            screenNo++;
        }
        
    }

    public void NextAlphabet() {
        if (screenNo % 2 != 0) {
            Destroy(clone);
            for (int i = 0; i < 3; i++) {
                SetChild(i, alphabetNo + 1);
                alphabetNo++;
            }
            clone = Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
            screenNo++;
        }
        else {
            EmbedActivity();   
        }
    }

    public void RepeatAlphabet() {
        Destroy(clone);
        int newAlphabetNo = alphabetNo - 2;
        for (int i = 0; i < 3; i++) {
            SetChild(i, newAlphabetNo);
            newAlphabetNo++;
        }
        clone = Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity); 
    }
    public void SetChild(int childNo, int alphabetNo) {
        alphabetContainer.transform.GetChild(childNo).GetComponent<SpriteRenderer>().sprite = urduAlphabetsSprite[alphabetNo];
    }

    public void EmbedActivity() {
        SceneManager.LoadScene("ULR1-Activity");
    }
}
