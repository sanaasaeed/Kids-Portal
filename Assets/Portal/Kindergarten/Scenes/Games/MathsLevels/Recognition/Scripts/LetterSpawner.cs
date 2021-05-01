using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public List<GameObject> numbers;
    public List<float> xPositions = new List<float>();
    private float lastPosZ = 15f;

    [SerializeField] private float gap = 60f;

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
        lastPosZ += gap;
    }
}
// TODO: System to collect numbers
// TODO: Cloned game objects should be destroyed when their use is done.
