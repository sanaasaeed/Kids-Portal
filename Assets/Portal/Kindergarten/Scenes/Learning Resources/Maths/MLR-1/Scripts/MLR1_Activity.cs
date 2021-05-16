using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLR1_Activity : MonoBehaviour {
    [SerializeField] private List<GameObject> numbers;
    private MLR1 mainScript;
    
    void Start() {
        mainScript = FindObjectOfType<MLR1>();
        Sprite randomSprite = mainScript.mathLetters[Random.Range(MLR1.letterNo-5, MLR1.letterNo)];
        int initialIndex = Random.Range(0, numbers.Count);
        numbers[initialIndex].GetComponent<SpriteRenderer>().sprite = randomSprite;
        foreach (var number in numbers) {
            if (number.GetComponent<SpriteRenderer>().sprite != randomSprite) {
                number.GetComponent<SpriteRenderer>().sprite = mainScript.mathLetters[Random.Range(0, mainScript.mathLetters.Count)];
            }
        }
    }
}
