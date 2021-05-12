using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urdu : MonoBehaviour {
    [SerializeField] private List<Sprite> urduAlphabetsSprite;
    [SerializeField] private GameObject alphabetContainer;
    private GameObject clone;
    private static int alphabetNo = 0;
    private int totalScrens = 13;

    private void Start() {
        SetChild(0, alphabetNo);
        for (int i = 1; i < 3; i++) {
            SetChild(i, alphabetNo + 1);
            alphabetNo++;
        }
        clone =  Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
    }

    private void NextAlphabet() {
            Debug.Log("Space pressed");
            Destroy(clone);
            for (int i = 0; i < 3; i++) {
                Debug.Log("Alphabet No: " + alphabetNo);
                SetChild(i, alphabetNo + 1);
                alphabetNo++;
            }
            clone = Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity); 
        }

    public void SetChild(int childNo, int alphabetNo) {
        alphabetContainer.transform.GetChild(childNo).GetComponent<SpriteRenderer>().sprite = urduAlphabetsSprite[alphabetNo];
    }
}
