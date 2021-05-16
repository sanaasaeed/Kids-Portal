using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    
    [SerializeField] private TMP_InputField fromInputField;
    [SerializeField] private TMP_InputField toInputField;
    [SerializeField] private GameObject panel;
    public int from = 0;
    public int to = 0;
    private MLR1 mainScript;

    private void Start() {
        mainScript = GetComponent<MLR1>();
        panel.SetActive(true);
    }

    public void GetInputValue() {
        from = int.Parse(fromInputField.text);
        to = int.Parse(toInputField.text);
        panel.SetActive(false);
        mainScript.StartLearning();
    }
}
