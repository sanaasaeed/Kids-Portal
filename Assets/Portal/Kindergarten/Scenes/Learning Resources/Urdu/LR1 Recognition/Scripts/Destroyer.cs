using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == ULR1Activity.nextAlphabet) {
            Destroy(gameObject);
        }
    }
}
