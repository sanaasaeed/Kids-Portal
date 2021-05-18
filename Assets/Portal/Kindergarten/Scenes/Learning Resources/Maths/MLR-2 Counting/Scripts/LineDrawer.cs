using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {
    private LineRenderer m_lineRenderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    
    void Start() {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.positionCount = 2;
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            m_lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        }
    }
}
