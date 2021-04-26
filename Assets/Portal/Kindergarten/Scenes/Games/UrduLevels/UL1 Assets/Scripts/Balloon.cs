﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class Balloon : MonoBehaviour {
        [SerializeField] public float speed = 2f;
        private GameState gameState;
        public Sprite newSprite;
        private AudioManager audioManager;
        private float yUpperLimit = 8;

        private void Start() {
            gameState = FindObjectOfType<GameState>();
            audioManager = FindObjectOfType<AudioManager>();
            if (gameObject.CompareTag($"Enemy")) {
                gameState.letters.Remove(GameState.target);
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gameState.letters[Random.Range(0,
                    37)];
            }
        }
        private void Update() {
            if (transform.position.y > yUpperLimit) {
                if (gameObject.CompareTag("Target")) {
                    gameState.DecreaseScore();
                }
                Destroy(gameObject);
            }

            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }

        private void OnMouseEnter() {
            if (gameObject.CompareTag($"Target")) {
                gameState.IncreaseScore();
                if (gameState.CurrentScore == GameState.targetScore) {
                    if (SceneManager.GetActiveScene().name != "UL1-3") {
                        SceneLoader.LoadNextScene(); 
                    }
                    else {
                        SceneManager.LoadScene("UrduLevels"); // TODO: Add Win Screen
                    }
                }
                audioManager.PlayCorrectAudio();
                Destroy(gameObject);
            }

            if (gameObject.CompareTag($"Enemy")) {
                gameState.DecreaseScore();
                if (gameState.CurrentScore == 0) {
                    DynamicPlay.sceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene("GameOver");
                }
                audioManager.PlayWrongAudio();
                gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            }
        }
    }
}