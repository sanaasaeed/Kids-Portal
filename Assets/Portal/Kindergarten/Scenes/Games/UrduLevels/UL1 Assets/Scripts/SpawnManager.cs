using System.Collections.Generic;
using UnityEngine;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class SpawnManager : MonoBehaviour {
        [SerializeField] public List<GameObject> spawningObjects;
        [SerializeField] public float xRange = 5f;
        private float delay = 2;
        private  float interval = 1f;
        private float yPos =-8;
    
        void Start()
        {
            InvokeRepeating(nameof(SpawnRandomBalloons), delay, interval);
        }

        void SpawnRandomBalloons() {
            int index = Random.Range(0, spawningObjects.Count);
            Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), yPos, -2);
            Instantiate(spawningObjects[index], spawnPos, spawningObjects[index].transform.rotation);
        }
    }
}
