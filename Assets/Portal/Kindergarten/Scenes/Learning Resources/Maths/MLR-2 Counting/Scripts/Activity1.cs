using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Activity1 : MonoBehaviour {
    [SerializeField] private List<Sprite> numbers;
    [SerializeField] private List<Sprite> objects;
    [SerializeField] private List<GameObject> objPrefabs;
    [SerializeField] private List<GameObject> clones;
    [SerializeField] private List<TMP_InputField> inputFields; 
    private Sprite currentNo;
    private List<float> yPositions;
    private void Start() {
        /*yPositions = new List<float>(){2f, 0f, -2.2f, -4.5f};
        foreach (var digitPrefab in digitPrefabs) {
            int randomIndex = Random.Range(0, numbers.Count);
            currentNo = numbers[randomIndex];
            digitPrefab.GetComponent<SpriteRenderer>().sprite = numbers[randomIndex];
            numbers.Remove(numbers[randomIndex]);
            int randomYIndex = Random.Range(0, yPositions.Count); 
            Debug.Log("Random Y index: " + yPositions[randomYIndex]);
            foreach (var objPrefab in objPrefabs) {
                if (objPrefab.name == currentNo.name) {
                    Instantiate(objPrefab, new Vector3(0, yPositions[randomYIndex], 0), Quaternion.identity);
                }
            }
            yPositions.Remove(yPositions[randomYIndex]);
        }*/
        SetCountingObjects();
    }

    void SetCountingObjects() {
        yPositions = new List<float>(){2f, 0f, -2.2f, -4.5f};
        int indexNo = 0;
        for (int i = 0; i < 4; i++) {    
            int randomIndex = Random.Range(0, numbers.Count);
            currentNo = numbers[randomIndex];
            foreach (var objPrefab in objPrefabs) {
                if (objPrefab.name == currentNo.name) {
                    var clone = Instantiate(objPrefab, new Vector3(0, yPositions[indexNo], 0), Quaternion.identity);
                    clones.Add(clone);
                    indexNo++;
                }
            }
            Debug.Log(clones[i]);
        }
    }

    public void ExtractAnswers() {
        for (int i = 0; i < 4; i++) {
            string ans = inputFields[i].text;
            CheckAnswers(ans, i);
        }
    }

    void CheckAnswers(string ans, int i) {
        if (clones[i].name.Contains(ans)) {
            Debug.Log("Correct ans");
        }
    }
}
