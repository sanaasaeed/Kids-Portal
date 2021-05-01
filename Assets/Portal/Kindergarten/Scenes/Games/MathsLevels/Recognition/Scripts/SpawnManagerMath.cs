using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerMath : MonoBehaviour {
    private RoadSpawner roadSpawner;
    private PlotSpawner plotSpawner;
    private ObstacleSpawner obstacleSpawner;
    private NumberSpawner m_numberSpawner;

    private void Start() {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
        obstacleSpawner = GetComponent<ObstacleSpawner>();
        m_numberSpawner = GetComponent<NumberSpawner>();
    }

    public void SpawnTriggerEnter() {
        roadSpawner.MoveRoad();
        plotSpawner.spawnPlot();
        m_numberSpawner.SpawnNumbers();
        obstacleSpawner.SpawnObstacles();
    }
}
