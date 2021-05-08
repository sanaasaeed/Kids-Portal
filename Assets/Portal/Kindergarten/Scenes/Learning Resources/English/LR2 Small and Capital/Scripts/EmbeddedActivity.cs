using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EmbeddedActivity : MonoBehaviour {
    [SerializeField] public List<GameObject> horizontalList1;
    [SerializeField] public List<GameObject> horizontalList2;
    [SerializeField] public List<GameObject> horizontalList3;
    [SerializeField] public List<GameObject> horizontalList4;
    [SerializeField] public List<Sprite> smallAlphabets;
    [SerializeField] public List<Sprite> capitalAlphabets;
   
    private void Start() {
        FillCapitalLetters();
        FillHorizontal();
    }

    public void NextBtn() {
        GameRunner.alphabetNo = GameRunner.checkPoint;
        SceneManager.LoadScene("E-LR-2");
    } 

    public void PrevBtn() {
        GameRunner.alphabetNo = GameRunner.checkPoint - GameRunner.interval;
        SceneManager.LoadScene("E-LR-2");
    }

    public void FillCapitalLetters() {
        horizontalList1[0].GetComponent<SpriteRenderer>().sprite =capitalAlphabets[GameRunner.alphabetNo - 
            (GameRunner.interval)];
        horizontalList2[0].GetComponent<SpriteRenderer>().sprite = capitalAlphabets[GameRunner.alphabetNo - (GameRunner.interval - 1)];
        horizontalList3[0].GetComponent<SpriteRenderer>().sprite = capitalAlphabets[GameRunner.alphabetNo - (GameRunner.interval - 2)];
        horizontalList4[0].GetComponent<SpriteRenderer>().sprite = capitalAlphabets[GameRunner.alphabetNo - (GameRunner.interval - 3)];
    }

    void FillHorizontal() {
        FillAllSprites(GameRunner.interval, horizontalList1);
        FillAllSprites((GameRunner.interval - 1), horizontalList2);
        FillAllSprites((GameRunner.interval - 2), horizontalList3);
        FillAllSprites((GameRunner.interval - 3), horizontalList4);
    }
    void FillAllSprites(int minus, List<GameObject> horizontalList) {
        int randomIndex = Random.Range(1, horizontalList1.Count);
        horizontalList[randomIndex].GetComponent<SpriteRenderer>().sprite =
            smallAlphabets[GameRunner.alphabetNo - (minus)];
        for (int i = 1; i < horizontalList.Count; i++) {
            if (i != randomIndex) {
                horizontalList[i].GetComponent<SpriteRenderer>().sprite = smallAlphabets[Random.Range(0,
                    smallAlphabets.Count)];
            }
        }
    }
}
