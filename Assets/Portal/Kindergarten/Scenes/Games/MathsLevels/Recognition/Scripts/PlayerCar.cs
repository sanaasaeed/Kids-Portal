using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour {
    public float speed = 30f;
    private Rigidbody rb;
    public float turnSpeed = 10f;
    public SpawnManagerMath spawnManager;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        /* TODO: Change the movement to linear dont allow going back and lane wise movement add in it. */
        /*float horizontalInput = Input.GetAxis("Horizontal") * speed/2;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right  * Time.deltaTime * speed);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Translate(Vector3.left  * Time.deltaTime * speed);
        }*/
        float horizontalInput = Input.GetAxis("Horizontal") * speed / 2;
        float forwardInput = Input.GetAxis("Vertical") * speed;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // if (forwardInput > 0) {
        //     //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //     transform.Translate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        // }
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("RoadTrigger")) {
            spawnManager.SpawnTriggerEnter();
        } else if (other.CompareTag("NumberTrigger")) {
            
            Destroy(other.gameObject);
        }
        
       
    }
}

// TODO: Randomize gap, player controller should be instant.. Add maths alphabets and collect those
// TODO: After adding maths letters give target of collecting them and avoiding every other thing
