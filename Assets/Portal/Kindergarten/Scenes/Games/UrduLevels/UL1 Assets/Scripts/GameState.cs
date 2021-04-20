using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class GameState : MonoBehaviour {
        public static Sprite target;
        public int CurrentScore = 10;
        [SerializeField] private GameObject targetLetterBalloon;
        [SerializeField] public List<Sprite> letters;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private List<int> levelScores;
        public static int targetScore;
    
        private void OnEnable() {
            SetTargetAlphabet();
            SetLevelScore();
        }
// Can make it more dynamic
        private void SetLevelScore() {
            if (SceneManager.GetActiveScene().name == "UL1-1") {
                targetScore = levelScores[0];
            } else if (SceneManager.GetActiveScene().name == "UL1-2") {
                targetScore = levelScores[1];
            } else if (SceneManager.GetActiveScene().name == "UL1-3") {
                targetScore = levelScores[2];
            }
        }

        public  void IncreaseScore() {
            CurrentScore += 10;
            scoreText.text = CurrentScore.ToString();
        }
    
        public void DecreaseScore() {
            CurrentScore -= 10;
            scoreText.text = CurrentScore.ToString();
        }

        public void SetTargetAlphabet() {
            target = letters[Random.Range(0, 37)];
            targetLetterBalloon.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = target;
        }
    }
}

/*
TODOS:
- MainMenu
- Add more levels
- Add scores
- Speed balloons up in next levels
- Game Over
- Pause Menu
- Goals Menu
*/