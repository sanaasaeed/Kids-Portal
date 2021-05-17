using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MLR2 : MonoBehaviour {
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject digit;
    [SerializeField] private List<Sprite> numbers;
    public static int letterNo = 0;
    private GameObject clone;
    void Start() {
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        Debug.Log(numbers[letterNo]);
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(0+ (i+1), -2, -1), quaternion.identity);
        }
        letterNo++;
    }

    public void NextBtn() {
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(-1 + (i+1), -2, -1), quaternion.identity);
        }
        letterNo++;
    }
    
}
