using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetList;
    [SerializeField] private GameObject tarHarf;
    void Start() {
        tarHarf.GetComponent<SpriteRenderer>().sprite = alphabetList[ULR1.alphabetNo];
    }

    public void BackBtn() {
        SceneManager.LoadScene("ULR-1");
    }
}
