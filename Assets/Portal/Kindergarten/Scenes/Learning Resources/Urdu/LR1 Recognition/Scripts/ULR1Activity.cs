using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1Activity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    public void BackBtn() {
        SceneManager.LoadScene("ULR-1");
    }
}
