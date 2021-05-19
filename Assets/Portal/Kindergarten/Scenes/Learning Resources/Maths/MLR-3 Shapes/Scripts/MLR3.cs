using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MLR3 : MonoBehaviour {
    [SerializeField] private List<GameObject> shapesPrefab;
    [SerializeField] private TextMeshProUGUI shapeText;
    [SerializeField] private List<Sprite> shapes;

    private void Start() {
        int randomIndex = Random.Range(0, shapesPrefab.Count);
        GameObject currentPrefab = shapesPrefab[randomIndex];
        Instantiate(currentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        shapeText.text = currentPrefab.name;
    }
    
    public void NextBtn(){
    
        }
}
