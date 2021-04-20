using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alphabets : MonoBehaviour {
    private GameState gameState;
    private float lowerLimit = 6;
    [SerializeField] private List<Sprite> alphabets;
    private AudioManager audioManager;

    private void Start() {
         gameState = FindObjectOfType<GameState>();
         audioManager = FindObjectOfType<AudioManager>();
          if (!gameObject.CompareTag("target")) {
             alphabets.Remove(GameState.target); 
             GetComponent<SpriteRenderer>().sprite = alphabets[Random.Range(0, 24)];
         }
    }

    void Update()
    {
        if (transform.position.y < -lowerLimit) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (gameObject.CompareTag("target")) {
            audioManager.PlayCorrectAudio();
            gameState.IncreaseScore();
            
            Destroy(gameObject);
        }
        else if(gameObject.CompareTag("enemy")) {
           audioManager.PlayWrongAudio();
            gameState.DecreaseScore();
            gameState.AnimateBasket();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!gameObject.CompareTag("target")) {
            gameState.StopAnimation();
        }
    }
}
