using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour {
    public static float speed = 30f;
    private Rigidbody rb;
    private AudioSource audio;
    public SpawnManagerMath spawnManager;
    public LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        levelManager.EnableLevelPopup();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal") * speed / 2;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("RoadTrigger")) {
            spawnManager.SpawnTriggerEnter();
        } else if (other.name.Contains(LevelManager.numberToGet.ToString())) {
            audio.Play();
            Destroy(other.gameObject);
            levelManager.IncreaseScore();
        } else if (!other.name.Contains(LevelManager.numberToGet.ToString())) {
            levelManager.DecreaseLives();
            //Time.timeScale = 0f;
            // Decrease Score
            // TODO: if time permits then destroy car physically
            // TODO: Shrink the colliders
            // TODO: See level problems solve them
            // TODO: Probability of chosen random number should be more
        }
    }
}