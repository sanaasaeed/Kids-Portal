using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmbeddedActivity : MonoBehaviour
{
    public void NextBtn() {
        GameRunner.alphabetNo = GameRunner.checkPoint;
        SceneManager.LoadScene("E-LR-2");
    }

    public void PrevBtn() {
        GameRunner.alphabetNo = GameRunner.checkPoint - 4;
        SceneManager.LoadScene("E-LR-2");
    }
}
