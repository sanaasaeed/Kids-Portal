using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlotSpawner : MonoBehaviour {
    private int amountOfPlots = 5;
    [SerializeField] private float plotSize = 60f;
    private float xPosLeft = -40f;
    private float xPosRight = 40f;
    private float lastPosz = 15f;

    [SerializeField] private List<GameObject> plots;

    private void Start() {
        for (int i = 0; i < amountOfPlots; i++) {
            spawnPlot();
        }
    }
    
    public void spawnPlot() {
        GameObject plotLeft = plots[Random.Range(0, plots.Count)];
        GameObject plotRight = plots[Random.Range(0, plots.Count)];

        float zPos = lastPosz + plotSize;
        Instantiate(plotLeft, new Vector3(xPosLeft, -1.8f, zPos), plotLeft.transform.rotation);
        Instantiate(plotRight, new Vector3(xPosRight, -1.8f, zPos), new Quaternion(0, 180, 0, 0));

        
        lastPosz += plotSize;
    }
}
