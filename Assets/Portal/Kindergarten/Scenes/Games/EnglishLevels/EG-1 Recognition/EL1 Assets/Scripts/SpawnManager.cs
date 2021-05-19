using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
    [SerializeField] List<GameObject> spawningObjects;
    private float delay = 4;
    private float interval = 1f;
    [SerializeField] public float xRange = 5.5f;
    private float yPos = 7f;

    private void Start() {
        InvokeRepeating(nameof(SpawnRandomAlphabets), delay, interval);
    }
    void SpawnRandomAlphabets() {
        int alphaIndex = Random.Range(0, spawningObjects.Count);
        Vector2 spawnPosition = new Vector2((Random.Range(-xRange, xRange)), yPos);
        Instantiate(spawningObjects[alphaIndex], spawnPosition, spawningObjects[alphaIndex].transform.rotation);
    }
}
