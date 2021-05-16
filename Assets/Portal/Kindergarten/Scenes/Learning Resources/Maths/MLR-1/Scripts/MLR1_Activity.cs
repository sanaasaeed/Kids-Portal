using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLR1_Activity : MonoBehaviour {
    [SerializeField] private List<GameObject> numbers;
    private MLR1 mainScript;
    
    void Start() {
        mainScript = FindObjectOfType<MLR1>();
        Sprite randomSprite = mainScript.mathLetters[Random.Range(MLR1.letterNo-5, MLR1.letterNo)];
        Debug.Log("Random Sprite coming from activity" + randomSprite.name);
        Debug.Log("Dividing: " + (15/7));
    }
}
