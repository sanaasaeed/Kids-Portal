using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetList;
    [SerializeField] private GameObject tarHarf;
    void Start() {
        var index = Random.Range(ULR1.alphabetNo, ULR1.alphabetNo - 9);
        tarHarf.GetComponent<SpriteRenderer>().sprite = alphabetList[index];
    }

    public void BackBtn() {
        SceneManager.LoadScene("ULR-1");
    }
}
