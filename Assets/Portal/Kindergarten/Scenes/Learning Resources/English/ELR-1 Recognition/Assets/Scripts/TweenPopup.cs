using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TweenPopup : MonoBehaviour {
    public TextMeshProUGUI resultText;

    public void OpenPopup() {
        transform.LeanMoveLocalY(125f, 0.5f).setEaseInQuart();
    }
}
