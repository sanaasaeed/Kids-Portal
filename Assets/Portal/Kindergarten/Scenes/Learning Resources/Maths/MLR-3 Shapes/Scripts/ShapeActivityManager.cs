using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapeActivityManager : MonoBehaviour {
    [SerializeField] private List<Sprite> shapeImages; 
    public NoOfShapesList noOfShapesList = new NoOfShapesList();
    [SerializeField] private GameObject shapePrefab;
    [SerializeField] private TMP_InputField triangleTextField;
    [SerializeField] private TMP_InputField circleTextField;
    [SerializeField] private TMP_InputField squareTextField;
    [SerializeField] private TMP_InputField rectangleTextField;
    [SerializeField] private TMP_Text message;
    private int count;
    void Start() {
        message.text = "";
            count = 0;
        shapePrefab.GetComponent<SpriteRenderer>().sprite = shapeImages[count];
    }

    public void NextBtn() {
        if (count < (shapeImages.Count)) {
            CheckAnswers();
        }
    }

    void CheckAnswers() {
        //Debug.Log(noOfShapesList.shapeList[count].noOfShapes[0]);
        if (triangleTextField.text == "" || circleTextField.text == "" || squareTextField.text == "" ||
            rectangleTextField.text == "") {
            message.text = "Fill All Fields";
            StartCoroutine(Wait());
        }
        if (int.Parse(triangleTextField.text) == noOfShapesList.shapeList[count].noOfShapes[0] && int.Parse
        (circleTextField.text) == noOfShapesList.shapeList[count].noOfShapes[1] && int.Parse(squareTextField.text) == 
        noOfShapesList.shapeList[count].noOfShapes[2] && int.Parse(rectangleTextField.text) == noOfShapesList
        .shapeList[count].noOfShapes[3]) {
            if (count < (shapeImages.Count - 1)) {
                shapePrefab.GetComponent<SpriteRenderer>().sprite = shapeImages[count + 1];
                count++;
                triangleTextField.text = "";
                circleTextField.text = "";
                rectangleTextField.text = "";
                squareTextField.text = "";
            }
            else {
                message.text = "Great Effort!";
                StartCoroutine(Wait());
                SceneManager.LoadScene("Math");
            }
        }
        else {
            message.text = "Try Again";
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        message.text = "";
    }
}


[System.Serializable]
public class NoOfShapes {
    public List<int> noOfShapes;
}
 
[System.Serializable]
public class NoOfShapesList {
    public List<NoOfShapes> shapeList;
}
