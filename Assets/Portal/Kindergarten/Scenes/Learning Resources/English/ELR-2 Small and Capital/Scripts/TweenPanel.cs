using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TweenPanel : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI resultText;

    public void OpenPanel() {
        LeanTween.moveLocalY(gameObject, 100f, 0.5f).setEaseInQuart();
    }

    public void CancelPanel() {
        LeanTween.cancelAll();
    }
}
