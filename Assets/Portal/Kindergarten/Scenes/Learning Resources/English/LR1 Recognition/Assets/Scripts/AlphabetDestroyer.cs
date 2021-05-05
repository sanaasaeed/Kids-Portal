using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetDestroyer : MonoBehaviour {
    private ActivitySound m_activitySound;

    private void Start() {
        m_activitySound = FindObjectOfType<ActivitySound>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_activitySound.selectedAlphabet.name)) {
            Destroy(gameObject);
        }
        
    }
}
