﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ULR1Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetList;
    [SerializeField] private GameObject tarHarf;
    [SerializeField] private List<GameObject> otherHarfs;
    void Start() {
        var index = Random.Range(ULR1.alphabetNo, ULR1.alphabetNo - 9);
        var targetAlphabet = alphabetList[index];
        var nextAlphabet = alphabetList[index + 1];
        tarHarf.GetComponent<SpriteRenderer>().sprite = targetAlphabet;
        otherHarfs[Random.Range(0, otherHarfs.Count)].GetComponent<SpriteRenderer>().sprite = nextAlphabet;
        Debug.Log(targetAlphabet);
        Debug.Log(nextAlphabet);
        foreach (var otherHarf in otherHarfs) {
            if (otherHarf.GetComponent<SpriteRenderer>().sprite != nextAlphabet) {
                otherHarf.GetComponent<SpriteRenderer>().sprite = alphabetList[Random.Range(0, alphabetList.Count)];
            }
        }
    }

    private void OnMouseDown() {
        
    }

    public void BackBtn() {
        SceneManager.LoadScene("ULR-1");
    }
}
