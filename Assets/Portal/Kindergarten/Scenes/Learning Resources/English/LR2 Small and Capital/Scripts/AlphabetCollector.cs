using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetCollector : MonoBehaviour {
    private EmbeddedActivity m_embeddedActivity;
    private void Start() {
        m_embeddedActivity = FindObjectOfType<EmbeddedActivity>();
    }

    private void OnMouseDown() {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList1[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower())) {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList2[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower())) {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList3[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower())) {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name.Contains(m_embeddedActivity.horizontalList4[0]
            .GetComponent<SpriteRenderer>().sprite.name.ToLower())) {
            Destroy(gameObject);
        }
        
    }
}
