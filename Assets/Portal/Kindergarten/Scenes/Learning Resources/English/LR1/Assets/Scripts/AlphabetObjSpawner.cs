using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetObjSpawner : MonoBehaviour {
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] private GameObject objectPrefab;
    void Start() {
        StartCoroutine(nameof(WaitAndInitialize));
    }
    IEnumerator WaitAndInitialize() {
        yield return new WaitForSeconds(4);
        Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
    }
}  