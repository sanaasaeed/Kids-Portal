using System;
using UnityEngine;

public class Shape : MonoBehaviour {
    private Transform shapePos;
    private Vector2 initalPos;
    private Vector2 mousePos;
    [SerializeField] GameObject SpawnManager;
    private float deltaX, deltaY;
    public static int moves = 0;

    private void Start() {
        initalPos = transform.position;
    }
    

    private void OnMouseDrag() {
        if (!gameObject.name.Contains("done")) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x - deltaX, mousePos.y - deltaY, -1);
        }
    }
    
    public void NextRound() {
        if (moves == 3) {
            foreach (var clones in ObjectSpawner.clonedObjects) {
                Destroy(clones);
            }
            moves = 0;
            Debug.Log(moves);
            ObjectSpawner.clonedObjects.Clear();
            SpawnManager.GetComponent<ObjectSpawner>().SetShapes();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetMouseButtonUp(0)) {
            if (gameObject.CompareTag(other.tag)) {
                /*if (Mathf.Abs(transform.position.x - other.transform.position.x) <= 3f &&
                    Mathf.Abs(transform.position.y - other.transform.position.y) <= 3f) {*/
                    transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
                    gameObject.name += "done";
                    moves += 1;
                    Debug.Log(moves);
                   NextRound();
                   
            }
            else {
                transform.position = new Vector3(initalPos.x, initalPos.y, -1);
            }
        }
    }
}
