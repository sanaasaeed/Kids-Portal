using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSetterInPopup : MonoBehaviour {
    [SerializeField] private Text leveltext;
    private int levelToPlay = 9;
    void Start() {
        leveltext.text = "Level " + levelToPlay;
    }

}
