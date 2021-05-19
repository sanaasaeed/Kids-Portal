using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetList;
    [SerializeField] private GameObject tarHarf;
    [SerializeField] private List<GameObject> otherHarfs;
    public static Sprite nextAlphabet;
    void Start() {
        var index = Random.Range(ULR1.alphabetNo, ULR1.alphabetNo - 6);
        var targetAlphabet = alphabetList[index];
        nextAlphabet = alphabetList[index + 1];
        tarHarf.GetComponent<SpriteRenderer>().sprite = targetAlphabet;
        otherHarfs[Random.Range(0, otherHarfs.Count)].GetComponent<SpriteRenderer>().sprite = nextAlphabet;
        foreach (var otherHarf in otherHarfs) {
            if (otherHarf.GetComponent<SpriteRenderer>().sprite != nextAlphabet) {
                otherHarf.GetComponent<SpriteRenderer>().sprite = alphabetList[Random.Range(0, alphabetList.Count)];
            }
        }
    }

    public static void Back() {
        SceneManager.LoadScene("ULR-1");
    }
}
