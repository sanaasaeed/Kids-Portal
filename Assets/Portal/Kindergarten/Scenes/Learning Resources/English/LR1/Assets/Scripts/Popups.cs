using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popups : MonoBehaviour
{
    [SerializeField] private GameObject instructionPopup;
    
    void Start() {
        StartCoroutine(nameof(WaitAndDestroy));
    }
    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(3);
        instructionPopup.SetActive(false);
    }
}
