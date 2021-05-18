using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Activity1 : MonoBehaviour {
    [SerializeField] private List<Sprite> numbers;
    [SerializeField] private List<Sprite> objects;
    [SerializeField] private List<GameObject> objPrefabs;
    [SerializeField] private List<GameObject> digitPrefabs;
    private Sprite currentNo;
    private void Start() {
        foreach (var digitPrefab in digitPrefabs) {
            int randomIndex = Random.Range(0, numbers.Count);
            currentNo = numbers[randomIndex];
            digitPrefab.GetComponent<SpriteRenderer>().sprite = numbers[randomIndex];
            numbers.Remove(numbers[randomIndex]);
            foreach (var objPrefab in objPrefabs) {
                Debug.Log(objPrefab.name + " Object prefab");
                Debug.Log(currentNo.name + " Current name");
                if (objPrefab.name == currentNo.name) {
                    Instantiate(objPrefab);
                }
            }
        }
    }
}
