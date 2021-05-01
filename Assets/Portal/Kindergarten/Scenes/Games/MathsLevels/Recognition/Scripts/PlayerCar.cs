using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour {
    public float speed = 30f;
    private Rigidbody rb;
    private AudioSource audio;
    public SpawnManagerMath spawnManager;

    private void Start() {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal") * speed / 2;
        float forwardInput = Input.GetAxis("Vertical") * speed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("RoadTrigger")) {
            spawnManager.SpawnTriggerEnter();
        } else if (other.CompareTag("NumberTrigger")) {
            audio.Play();
            // TODO: Only collect a certain number thats displayed on the screen
            // TODO: Subtasks: 1. Make a panel or something to display the number
            // TODO: 2. Choose a random number, display on that panel
            // TODO: 3. Tag those numbers as target by some means. 
            // TODO: 4. Now only collect those targets and if user collects something else than he should be punished game should be somewhat over or something life should reduce or something. 
            Destroy(other.gameObject);
        }
    }
}

// TODO: Randomize gap, player controller should be instant.. Add maths alphabets and collect those
// TODO: After adding maths letters give target of collecting them and avoiding every other thing
