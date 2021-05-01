using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour {
    public List<GameObject> obstacles;
    public List<float> xPositions = new List<float>();
    private float lastPosZ = 15f;

    [SerializeField] private float gap = 60f;

    private void Start() {
        for (int i = 0; i < obstacles.Count; i++) {
            SpawnObstacles();
        }
    }

    public void SpawnObstacles() {
        int index = Random.Range(0, obstacles.Count);
        int randomXPosIndex = Random.Range(0, xPositions.Count);
        Vector3 posOfObstacle = new Vector3(xPositions[randomXPosIndex], -1.6f, lastPosZ);
        Instantiate(obstacles[index], posOfObstacle, transform.rotation);
        lastPosZ += gap;
    }
}
