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
    private List<float> yPositions;
    private void Start() {
        yPositions = new List<float>(){2f, 0f, -2.2f, -4.5f};
        foreach (var digitPrefab in digitPrefabs) {
            int randomIndex = Random.Range(0, numbers.Count);
            currentNo = numbers[randomIndex];
            digitPrefab.GetComponent<SpriteRenderer>().sprite = numbers[randomIndex];
            numbers.Remove(numbers[randomIndex]);
            int randomYIndex = Random.Range(0, yPositions.Count); 
            Debug.Log("Random Y index: " + randomYIndex);
            foreach (var objPrefab in objPrefabs) {
                if (objPrefab.name == currentNo.name) {
                    Instantiate(objPrefab, new Vector3(0, yPositions[randomYIndex], 0), Quaternion.identity);
                }
            }
            yPositions.Remove(yPositions[randomYIndex]);
        }
       

    }
}
