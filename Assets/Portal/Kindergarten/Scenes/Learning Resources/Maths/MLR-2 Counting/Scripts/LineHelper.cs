using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHelper : MonoBehaviour {
    [SerializeField] private GameObject Line_Drawer;
    public static Vector2 mousePos;
    public static Vector2 startMousePos;
    void Start() {
        
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(Line_Drawer);
        }
        /*
        if (Input.GetMouseButton(0)) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            m_lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        }*/
    }
}
