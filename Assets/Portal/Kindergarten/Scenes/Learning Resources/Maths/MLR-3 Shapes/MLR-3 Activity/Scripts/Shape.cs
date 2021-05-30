﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shape : MonoBehaviour {
    private Transform shapePos;
    private Vector2 initalPos;
    private Vector2 mousePos;
    [SerializeField] GameObject SpawnManager;
    private float deltaX, deltaY;
    public static int moves = 0;
    private static int rightMoves = 0;
    private static int wrongMoves = 0;
    private ObjectSpawner objspawner;
    private MLR3 mainScript;
    private float activityTimer = 0;
    private bool isActivityRunning = true;

    private void Start() {
        mainScript = FindObjectOfType<MLR3>();
        objspawner = FindObjectOfType<ObjectSpawner>();
        initalPos = transform.position;
        activityTimer = mainScript.levelTimer;
    }

    private void Update() {
        if (isActivityRunning) {
            activityTimer += Time.deltaTime;
        }
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
        if (rightMoves < 20) {
            if (Input.GetMouseButtonUp(0)) {
                if (gameObject.CompareTag(other.tag)) {
                    transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
                    gameObject.name += "done";
                    rightMoves++;
                    Debug.Log("Right moves: " + rightMoves);
                    moves += 1;
                    Debug.Log(moves);
                    NextRound();
                }
                else {
                    wrongMoves++;
                    Debug.Log("Wrong Moves: " + wrongMoves);
                    transform.position = new Vector3(initalPos.x, initalPos.y, -1);
                    
                }
            }
        }
        else {
            EndActivity();
        }
    }

    public void EndActivity() {
        int percentage = CalculatePercentage();
        Debug.Log(percentage);
        if (percentage > 70) {
            isActivityRunning = false;
            PlayerPrefs.SetInt("lrMathLevel", 3);
            PlayerPrefs.Save();
            SaveManager.Instance.SaveLRData("Maths", "Shapes", 1, activityTimer.ToString());
            SaveManager.Instance.UpdateExperiencePoints(20);
            SceneManager.LoadScene("Math");
        }
        else {
            objspawner.OpenPanel();
            StartCoroutine(ChangeScene());
        }
    }

    public int CalculatePercentage() {
        return (int) (0.5f + ((100f * rightMoves) / (rightMoves + wrongMoves)));
    }

    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("MLR-3");
    }
}
