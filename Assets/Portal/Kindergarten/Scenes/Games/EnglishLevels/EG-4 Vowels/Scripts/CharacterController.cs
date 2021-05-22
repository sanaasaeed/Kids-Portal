using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public Rigidbody2D rb;
    private float speed = 5f;
    private float movement;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    private void Update() {
        movement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            //Instantiate()
        }
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
    }
}
