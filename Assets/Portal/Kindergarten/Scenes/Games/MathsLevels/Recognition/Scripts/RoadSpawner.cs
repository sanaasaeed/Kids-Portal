using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {
    [SerializeField] private List<GameObject> roads;
    private float offset = 20f;

    private void Start() {
        if (roads != null && roads.Count > 0) {
            roads = roads.OrderBy(rd => rd.transform.position.z).ToList();
        }
    }

    public void MoveRoad() {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newZPos = roads[roads.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newZPos);
        roads.Add(moveRoad);
    }
}
