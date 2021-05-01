using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NumberSpawner : MonoBehaviour
{
    public List<GameObject> numbers;
    public List<float> xPositions = new List<float>();
    private float lastPosZ = 15f;
    [SerializeField] private float gap;

    private void Start() {
        for (int i = 0; i < numbers.Count; i++) {
            SpawnNumbers();
        }
    }

    public void SpawnNumbers() {
        int index = Random.Range(0, numbers.Count);
        int randomXPosIndex = Random.Range(0, xPositions.Count);
        Vector3 posOfObstacle = new Vector3(xPositions[randomXPosIndex], 0, lastPosZ);
        Instantiate(numbers[index], posOfObstacle, new Quaternion(0, 180,0,0));
        gap = Random.Range(50, 80);
        lastPosZ += gap;
    }
}