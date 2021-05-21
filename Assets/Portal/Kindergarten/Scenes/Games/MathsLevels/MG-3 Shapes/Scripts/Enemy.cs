using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {
    public float speed = 5f;
    public float rotateSpeed = 50;
    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;
    public float boundX = -11f;
    public Transform attackPoint;
    public GameObject enemyBullet;
    private Animator anim;
    private AudioSource explosionSound;

    private void Awake() {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    private void Start() {
        if (canRotate) {
            if (Random.Range(0, 2) > 0) {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }
        
        if (canShoot) {
            Invoke(nameof(StartShooting), Random.Range(1f, 3f));
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

    void StartShooting() {
        GameObject bullet = Instantiate(enemyBullet, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().isEmemyBullet = true;
        if (canShoot) {
            Invoke(nameof(StartShooting), Random.Range(1f, 3f));
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger Entered");
        if (other.CompareTag("playerbullet")) {
            anim.Play("Destroy");
            //Destroy(gameObject);
            StartCoroutine(WaitAndDestroy());
        }
    }

    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
