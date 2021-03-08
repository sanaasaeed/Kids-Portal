using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameState : MonoBehaviour
{
    private Animator basketAnimation;
    [SerializeField] private GameObject targetAlphabetPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private List<Sprite> alphabets;
    private int count = 0;
    public static Sprite target;
    public static int levelScore;

    private void OnEnable() {
        SetTargetAlphabet();
        SetLevelScore();
    }

    void Start() {
        basketAnimation = FindObjectOfType<Animator>();
    }

    public void SetTargetAlphabet() {
        target = alphabets[Random.Range(0, 25)];
        targetAlphabetPrefab.GetComponent<SpriteRenderer>().sprite = target;
    }

    public void AnimateBasket() {
        basketAnimation.enabled = true;
    }

    public void StopAnimation() {
        basketAnimation.enabled = false;
    }

    public void IncreaseScore() {
        count += 10;
        if (count == levelScore) {
            if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
                SceneLoader.LoadNextSceneWithoutLoading();
        }

        scoreText.text = count.ToString();
    }

    public void DecreaseScore() {
        count -= 10;
        if(count < 0) {
            SceneLoader.LoadLastScene();
        }
        scoreText.text = count.ToString();
    }

    public void SetLevelScore() {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            levelScore = 50;
        } else if (SceneManager.GetActiveScene().buildIndex == 2) {
            levelScore = 50;
        } else if (SceneManager.GetActiveScene().buildIndex == 3) {
            levelScore = 70;
        }
    }
}
