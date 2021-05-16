using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MLR1 : MonoBehaviour {
    [SerializeField] private List<Sprite> mathLetters;
    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private GameObject sunflowerPrefab;
    void Start() {
        letterPrefab.GetComponent<SpriteRenderer>().sprite = mathLetters[0];
        for (int i = 0; i < Int32.Parse(mathLetters[0].name); i++) {
            Instantiate(sunflowerPrefab, new Vector3(0, -2, -1), quaternion.identity);
        }
    }

    public void NextBtn() {
        
    }
    void Update() {
        
    }
}
