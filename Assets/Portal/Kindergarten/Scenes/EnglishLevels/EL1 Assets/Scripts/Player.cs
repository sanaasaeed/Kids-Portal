using System;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float speed = 20;
    [SerializeField] float xRange = 5.5f;
    private Vector2 targetPos;

    private void Start() {
        targetPos = transform.position;
    }

    private void Update() {
        targetPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (!(Camera.main is null)) targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        Vector2 followXonly = new Vector2(targetPos.x, transform.position.y);
        transform.position =
            Vector2.Lerp(new Vector2(Mathf.Clamp(transform.position.x, -xRange, xRange), transform.position.y),
                followXonly, speed * Time.deltaTime);

        // Vector2(Mathf.Clamp(transform.position.x, -xRange,xRange), transform.position.y);
    }
}
