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
        } else if (other.name.Contains(LevelManager.numberToGet.ToString())) {
            audio.Play(); 
            // TODO: 4. Damage the car
            Destroy(other.gameObject);
        }
    }
}

// TODO: Randomize gap, player controller should be instant.. Add maths alphabets and collect those
// TODO: After adding maths letters give target of collecting them and avoiding every other thing
