using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {
    public float minY = -4.3f;
    public float maxY = 4.3f;
    public List<GameObject> objectPrefab;
    public GameObject targetPrefab;
    public float timer = 2f;
    private ShapeManager shapemanager;

    private void Start() {
        shapemanager = FindObjectOfType<ShapeManager>();
        Debug.Log(shapemanager.randmShapeSprite);
        targetPrefab.GetComponent<SpriteRenderer>().sprite = shapemanager.randmShapeSprite;
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies() {
        float posY = Random.Range(minY, maxY);
        Vector3 tmp = transform.position;
        tmp.y = posY;

        if (Random.Range(0, 2) > 0) {
            Instantiate(objectPrefab[Random.Range(0, objectPrefab.Count)], tmp, Quaternion.identity);
        }
        else {
            Instantiate(targetPrefab, tmp, Quaternion.Euler(0f, 0f, 90f));
        }
        Invoke("SpawnEnemies", timer);
    }
}
