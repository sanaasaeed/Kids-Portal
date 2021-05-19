using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MLR3 : MonoBehaviour {
    [SerializeField] private List<GameObject> shapesPrefab;
    [SerializeField] private TextMeshProUGUI shapeText;
    [SerializeField] private List<Sprite> shapes;
    public static int randomNextIndex;

    private void Start() {
        int randomIndex = Random.Range(0, shapesPrefab.Count);
        SetShape(randomIndex);
    }
    
    public void NextBtn() {
        RemoveClones();
        randomNextIndex = Random.Range(0, shapesPrefab.Count);
        SetShape(randomNextIndex);
    }

    public void RepeatBtn() {
        RemoveClones();
        SetShape(randomNextIndex);
    }

    public void SetShape(int randomIndex) {
        GameObject currentPrefab = shapesPrefab[randomIndex];
        Instantiate(currentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        shapeText.text = currentPrefab.name;
    }

    void RemoveClones() {
        var allClones = FindObjectsOfType<GameObject>();
        foreach (var clone in allClones) {
            if (clone.name.Contains("Clone")) {
                Destroy(clone);
            }
        }
    }
}
