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
    private float minX = -8f;
    private float maxX = 1.5f;
    private void Update() {
        movement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, attackPoint.position, Quaternion.Euler(0f,0f, 90));
        }
    }

    private void FixedUpdate() {
        Vector3 temp = transform.position;
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
        if (temp.x > maxX) {
            temp.x = maxX;
        }
        transform.position = temp;
        
        if (temp.x < minX) {
            temp.x = minX;
        }
        transform.position = temp;
    }
}
