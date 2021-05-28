using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
    public float speed = 5f;
    public float rotateSpeed = 50;
    public bool canRotate;
    public bool canMove = true;
    public float boundX = -11f;
    public GameObject player;
    private Animator anim;
    private AudioSource explosionSound;
    private ShapeManager shapeMngr;

    private void Awake() {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
        shapeMngr = FindObjectOfType<ShapeManager>();
    }

    private void Start() {
        if (canRotate) {
            if (Random.Range(0, 2) > 0) {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }
    }

    void Update() {
        Move();
        RotateEnemy();
    }

    void Move() {
        if (canMove) {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < boundX) {
                Destroy(gameObject);
            }
        }
    }

    void RotateEnemy() {
        if (canRotate) {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("playerSpaceship")) {
            shapeMngr.DecreaseScore();
        }
    }

    IEnumerator WaitAndDestroy(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    
}
