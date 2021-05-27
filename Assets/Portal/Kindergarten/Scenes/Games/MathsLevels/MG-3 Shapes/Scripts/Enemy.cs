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
    public GameObject player;
    public Transform attackPoint;
    public GameObject enemyBullet;
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
        if (other.CompareTag("playerbullet") && gameObject.CompareTag("enemySpaceship")) {
            canShoot = false;
            anim.Play("Destroy");
            explosionSound.Play();
            //Destroy(gameObject);
            StartCoroutine(WaitAndDestroy(0.5f));
        }

        if (gameObject.CompareTag("shape") && (!gameObject.name.Contains(shapeMngr.randomShape.GetComponent<Image>()
        .sprite.name) && (other.CompareTag("playerbullet"))
        )) {
            shapeMngr.IncreaseScore();
            explosionSound.Play();
            StartCoroutine(WaitAndDestroy(0.1f));
            
        } else if(gameObject.CompareTag("shape") && (gameObject.name.Contains(shapeMngr.randomShape.GetComponent<Image>()
            .sprite.name) && (other.CompareTag("playerbullet")))){
            shapeMngr.DecreaseHeart(player);
        }
    }

    IEnumerator WaitAndDestroy(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    
}
