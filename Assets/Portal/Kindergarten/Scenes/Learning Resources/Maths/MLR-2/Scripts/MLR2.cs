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
    private float lastEggPos = -6.8f;
    private GameObject clone;
    private int screenNo = 0;
    void Start() {
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        Debug.Log(numbers[letterNo]);
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(lastEggPos, -3.5f, -1), quaternion.identity);
        }
        letterNo++;
    }

    public void NextBtn() {
        screenNo++;
        if (screenNo % 3 == 0){
        }
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var allClone in allClones) {
            if (allClone.name.Contains("Clone")) {
                Destroy(allClone);
            }
        }
        digit.GetComponent<SpriteRenderer>().sprite = numbers[letterNo];
        lastEggPos = -6.8f;
        for (int i = 0; i < Int32.Parse(numbers[letterNo].name); i++) {
            Instantiate(egg, new Vector3(lastEggPos, -3.5f, -1), quaternion.identity);
            Debug.Log("Last Egg Position: " + lastEggPos);
            lastEggPos = lastEggPos + 1.5f;
        }
        letterNo++;
    }
    
}
