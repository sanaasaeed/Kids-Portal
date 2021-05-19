using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed = 5f;
   public float deactivateTimer = 3f;

   private void Start() {
       Invoke("DeactivateGameObject", deactivateTimer);
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
}
