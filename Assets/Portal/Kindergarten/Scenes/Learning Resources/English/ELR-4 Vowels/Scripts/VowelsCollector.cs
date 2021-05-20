using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VowelsCollector : MonoBehaviour
{
    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("A") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("E") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("I") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("O") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("U")) {
            Destroy(gameObject);
        }
        else {
            // TODO: else logic
        }
    }
}
