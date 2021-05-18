using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    [SerializeField] private TMP_InputField fromInputField;
    [SerializeField] private TMP_InputField toInputField;
    [SerializeField] public GameObject panel;
    public int from;
    public int to;
    private MLR1 mainScript;

    private void Start() {
        mainScript = GetComponent<MLR1>();
    }

    public void GetInputValue() {
        from = int.Parse(fromInputField.text);
        to = int.Parse(toInputField.text);
        panel.SetActive(false);
        Destroy(panel);
        mainScript.StartLearning();
    }
}
