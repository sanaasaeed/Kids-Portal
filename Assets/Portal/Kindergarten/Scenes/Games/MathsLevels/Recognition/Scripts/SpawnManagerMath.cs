using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerMath : MonoBehaviour {
    private RoadSpawner roadSpawner;
    private PlotSpawner plotSpawner;
    private ObstacleSpawner obstacleSpawner;
    private LetterSpawner letterSpawner;

    private void Start() {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
        letterSpawner = GetComponent<LetterSpawner>();
    }

    public void SpawnTriggerEnter() {
        roadSpawner.MoveRoad();
        plotSpawner.spawnPlot();
        letterSpawner.SpawnNumbers();
        // obstacleSpawner.SpawnObstacles();
    }
}
