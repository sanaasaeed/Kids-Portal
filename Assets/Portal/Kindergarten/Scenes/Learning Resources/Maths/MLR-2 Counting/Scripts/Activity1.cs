using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Activity1 : MonoBehaviour {
    [SerializeField] private List<Sprite> numbers;
    [SerializeField] private List<Sprite> objects;
    [SerializeField] private List<GameObject> objPrefabs;
    [SerializeField] private List<GameObject> clones;
    [SerializeField] private List<TMP_InputField> inputFields;
    [SerializeField] private GameObject resultPanel;
    private MLR2 mainScript;
    private float activityTimer = 0;
    private bool isActivityRunning = true;
    private Sprite currentNo;
    private List<float> yPositions;
    public static int correctAnswers;
    private void Start() {
        mainScript = FindObjectOfType<MLR2>();
        SetCountingObjects();
        activityTimer = mainScript.levelTimer;
    }

    private void Update() {
        if (isActivityRunning) {
            activityTimer += Time.deltaTime;
        }
    }

    void SetCountingObjects() {
        yPositions = new List<float>(){2f, 0f, -2.2f, -4.1f};
        int indexNo = 0;
        for (int i = 0; i < 4; i++) {    
            int randomIndex = Random.Range(0, numbers.Count);
            currentNo = numbers[randomIndex];
            foreach (var objPrefab in objPrefabs) {
                if (objPrefab.name == currentNo.name) {
                    var clone = Instantiate(objPrefab, new Vector3(0, yPositions[indexNo], 0), Quaternion.identity);
                    clones.Add(clone);
                    indexNo++;
                }
            }
            Debug.Log(clones[i]);
        }
    }

    public void ExtractAnswers() {
        for (int i = 0; i < 4; i++) {
            string ans = inputFields[i].text;
            if (!string.IsNullOrEmpty(ans) && !string.IsNullOrWhiteSpace(ans)) {
                CheckAnswers(ans, i);
            }
        }
        // GREATER THAN 3 TO MAKE IT above 50% PASSING
        if (correctAnswers > 3) {
            isActivityRunning = false;
            PlayerPrefs.SetInt("lrMathLevel", 2);
            PlayerPrefs.Save();
            SaveManager.Instance.SaveLRData("Maths", "Counting", 1,activityTimer.ToString());
            SceneManager.LoadScene("Math");
        }
        else {
            OpenPanel();
            StartCoroutine(ChangeScene());
        }
    }

    void CheckAnswers(string ans, int i) {
        if (clones[i].name.Contains(ans)) {
            correctAnswers++;
        }
    }

    public void OpenPanel() {
        resultPanel.transform.LeanScale(Vector3.one, 0.3f);
    }

    public void ClosePanel() {
        resultPanel.transform.LeanScale(Vector3.one, 0.3f);
    }

    IEnumerator ChangeScene() {
        yield return new WaitForSeconds(0.3f);
        ClosePanel();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MLR-2");
    }
}
