using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    [SerializeField] private List<GameObject> outlinedShapePrefab;
    [SerializeField] private List<GameObject> filledShapePrefab;
    List<float> xpos = new List<float>(){5.5f, 0, 5.5f};
    void Start() {
        float i = -5.5f;
        while (i < 6f) {
            int randomNum = Random.Range(0, outlinedShapePrefab.Count);
            SetInitialShapes(i, randomNum);
            i += 5.5f;
        }
    }

    private void SetInitialShapes(float i, int randomNum) {
        
        int randomXPos = Random.Range(0, xpos.Count);
        Instantiate(outlinedShapePrefab[randomNum], new Vector3(i, 1, -1),Quaternion.identity);
        Instantiate(filledShapePrefab[randomNum], new Vector3(xpos[Random.Range(0, xpos.Count)], -3.3f, -1),Quaternion.identity);
    }
}
