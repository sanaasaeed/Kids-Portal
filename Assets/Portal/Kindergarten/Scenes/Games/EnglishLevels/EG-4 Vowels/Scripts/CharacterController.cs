using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public Rigidbody2D rb;
    private float speed = 5f;
    private float movement;
    private void Update() {
        movement = Input.GetAxisRaw("Horizontal") * speed;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
    }
}
