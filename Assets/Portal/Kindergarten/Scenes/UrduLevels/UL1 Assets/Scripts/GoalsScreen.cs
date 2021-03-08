using UnityEngine;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class GoalsScreen : MonoBehaviour {
        public static bool isGoalsScreenOpened = true;
        [SerializeField] private GameObject goalsScreen;
        [SerializeField] private GameObject targetLetterBalloon;

    
        //private GameState gameState;

        /*
    private void OnEnable() {
        gameState = FindObjectOfType<GameState>();
        gameState.SetTargetAlphabet();
    }*/

        private void Start() {
            Time.timeScale = 0f;
            targetLetterBalloon.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Instantiate(targetLetterBalloon, new Vector2(0,0), targetLetterBalloon.transform.rotation);
        
        }

        public void CloseGoalsScreen() {
            Time.timeScale = 1f;
            if (isGoalsScreenOpened) {
                goalsScreen.SetActive(false);
            }
        }
    }
}
