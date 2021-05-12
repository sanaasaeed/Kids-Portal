using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ULR1Activity : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetList;
    void Start() {
        
    }

    public void BackBtn() {
        SceneManager.LoadScene("ULR-1");
    }
}
