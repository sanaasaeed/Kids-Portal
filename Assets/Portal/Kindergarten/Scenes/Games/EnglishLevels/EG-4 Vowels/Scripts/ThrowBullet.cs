using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBullet : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 4f;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
    }
}
