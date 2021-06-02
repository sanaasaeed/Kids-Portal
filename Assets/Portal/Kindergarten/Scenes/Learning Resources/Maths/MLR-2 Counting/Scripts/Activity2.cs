using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Activity2 : MonoBehaviour {
    [SerializeField] private List<Sprite> numbers;
    private static int train1Index;
    private static int train2Index;
    [SerializeField] private List<GameObject> train1numbers;
    [SerializeField] private List<GameObject> train2numbers;
    [SerializeField] private TMP_InputField train1input;
    [SerializeField] private TMP_InputField train2input;
    [SerializeField] private GameObject tryAgainPanel;
    private static int targetScore = 2;
    private static int score = 0;
    private void Start() {
        SetTrainNumbers();
    }

    public void NextBtn() {
        CheckTargetScore();
        int train1inputVal = Int32.Parse(this.train1input.text);
        int train2inputVal = Int32.Parse(this.train2input.text);
        if (train1inputVal == Int32.Parse(train1numbers[1].GetComponent<SpriteRenderer>().sprite.name) && train2inputVal == Int32.Parse(train2numbers[2].GetComponent<SpriteRenderer>().sprite.name)) {
            train1input.text = "";
            train2input.text = "";
            score++;
            Debug.Log(score);
            SetTrainNumbers();
        }
        else {
            tryAgainPanel.SetActive(true);
            StartCoroutine(SetActiveFalse());
        }
    }

    IEnumerator SetActiveFalse() {
        yield return new WaitForSeconds(0.5f);
        tryAgainPanel.SetActive(false);
    }

    public void SetTrainNumbers() {
        train1Index = UnityEngine.Random.Range(0, numbers.Count);
        train2Index = UnityEngine.Random.Range(0, numbers.Count);

        if (train1Index < (numbers.Count-4) && train2Index < (numbers.Count-4)) {
            foreach (var train1Number in train1numbers) {
                train1Number.GetComponent<SpriteRenderer>().sprite = numbers[train1Index];
                train1Index++;
            }
        
            foreach (var train2Number in train2numbers) {
                train2Number.GetComponent<SpriteRenderer>().sprite = numbers[train2Index];
                train2Index++;
            }
        }
        else {
            SetTrainNumbers();
        }
        
    }

    public void CheckTargetScore() {
        if (score == targetScore) {
            SceneManager.LoadScene("Math");
            score = 0;
        }
    } 
}
