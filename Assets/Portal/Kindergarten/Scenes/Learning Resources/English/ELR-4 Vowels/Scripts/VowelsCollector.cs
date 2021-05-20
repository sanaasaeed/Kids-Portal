using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VowelsCollector : MonoBehaviour {
    public static int count = 0;
    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("A") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("E") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("I") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("O") ||
            gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains("U")) {
            count++;
            Destroy(gameObject);
        }
        else {
            // TODO: else logic
        }

        if (count == 30) {
            Debug.Log("Game UNLOCKED");
            // TODO: GAME UNLOCKED
        }
        else if (count % 5 == 0) {
            Debug.Log(count);
            SceneManager.LoadScene("ELR4Activity");
        }

        
    }
}
