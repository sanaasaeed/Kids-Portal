using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed = 5f;
   public float deactivateTimer = 3f;
   [HideInInspector] public bool isEmemyBullet = false;
   private ShapeManager m_shapeManager;
   private void Start() {
       if (isEmemyBullet) {
           speed *= -1f;
       }
       Invoke("DeactivateGameObject", deactivateTimer);
       
       m_shapeManager = FindObjectOfType<ShapeManager>();
   }

   private void Update() {
       Move();
   }

   void Move() {
       Vector3 tmp = transform.position;
       tmp.x += speed * Time.deltaTime;
       transform.position = tmp;
   }
   void DeactivateGameObject() {
       Destroy(gameObject);
   }

   private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.GetComponent<SpriteRenderer>().sprite == m_shapeManager
       .randmShapeSprite) {
           m_shapeManager.IncreaseScore();
           Destroy(other.gameObject);
           Destroy(gameObject);
       }
       else if(!other.CompareTag("playerSpaceship")) {
           m_shapeManager.DecreaseScore();
           Destroy(gameObject);
       }
   }
}
