using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour {
    public static ObjectSpawner instance;
    [SerializeField] private List<GameObject> outlinedShapePrefab;
    [SerializeField] private List<GameObject> filledShapePrefab;
    public static List<GameObject> clonedObjects = new List<GameObject>();
    [SerializeField] private GameObject resultPanel;
    
    void Start() {
       SetShapes();
    }

    public void SetShapes() {
        List<float> xpos = new List<float>(){-5.5f, 0, 5.5f};
        float i = -5.5f;
        while (i < 6f) {
            int randomNum = Random.Range(0, outlinedShapePrefab.Count);
            int randomXPos = Random.Range(0, xpos.Count);
            GameObject outlineInstance =
                Instantiate(outlinedShapePrefab[randomNum], new Vector3(i, 1, -1), Quaternion.identity);
            GameObject shapedInstance = Instantiate(filledShapePrefab[randomNum],
                new Vector3(xpos[randomXPos], -3.3f, -1),
                Quaternion
                    .identity);
            xpos.RemoveAt(randomXPos);
            clonedObjects.Add(outlineInstance);
            clonedObjects.Add(shapedInstance);
            i += 5.5f;
        }
    }

    public void OpenPanel() {
        resultPanel.transform.LeanScale(Vector3.one, 0.4f);
    }
}
