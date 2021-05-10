using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urdu : MonoBehaviour {
    [SerializeField] private List<Sprite> urduAlphabetsSprite;
    [SerializeField] private GameObject alphabetContainer;
    private GameObject clone;

    private void Start() {
        clone =  Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Dpace pressed");
            
            Destroy(clone);
            new WaitForSeconds(3);
            Instantiate(alphabetContainer, new Vector3(0,0,-1), Quaternion.identity);
        }
    }
}
