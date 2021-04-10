using System;
using UnityEngine;

public class Shape : MonoBehaviour {
    private Transform shapePos;
    private Vector2 initalPos;
    private Vector2 mousePos;
    private float deltaX, deltaY;
    public static bool locked;

    private void Start() {
        initalPos = transform.position;
    }

    private void OnMouseDown() {
        if (!locked) {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag() {
        if (!locked) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x - deltaX, mousePos.y - deltaY, -1);
        }
    }

    //private void OnMouseUp(Collider other) {
      //  if (Mathf.Abs(transform.position.x - other.transform.position.x) <= 0.5f &&
      //      Mathf.Abs(transform.position.y - other.transform.position.y) <= 0.5f) {
      //      transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
      //  }
   // }

    /*private void OnTriggerEnter(Collider other) {
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("Entered");
            if (Mathf.Abs(transform.position.x - other.transform.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - other.transform.position.y) <= 0.5f) {
                        transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetMouseButtonUp(0)) {
            if (gameObject.CompareTag(other.tag)) {
                /*if (Mathf.Abs(transform.position.x - other.transform.position.x) <= 3f &&
                    Mathf.Abs(transform.position.y - other.transform.position.y) <= 3f) {*/
                    transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
                //}
            }
            else {
                transform.position = new Vector3(initalPos.x, initalPos.y, -1);
            }
        }
    }
}
