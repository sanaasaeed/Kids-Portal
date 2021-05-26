using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class ShapeManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public GameObject randomShape;
    [SerializeField] private List<Sprite> shapes;
    [SerializeField] private GameObject panel;
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Sprite emptyHeart;
    private int totalLife = 3;
    private int heartIndex = 0;
    private static int score = 0;
    private EnemySpawner enemySpawner;

    private void Start() {
        enemySpawner = FindObjectOfType<EnemySpawner>(); ;
        Sprite randmShapeSprite = shapes[Random.Range(0, shapes.Count)];
        Debug.Log("Random Sprite: " + randmShapeSprite);
        randomShape.GetComponent<Image>().sprite = randmShapeSprite;
        OpenPanel();
    }

    public void IncreaseScore() {
        score += 10;
        scoreText.text = score.ToString();
        if (score == 100) {
            // TODO: Win screen
            SceneManager.LoadScene("Math");
        }
    }

    public void DecreaseScore() {
        score -= 10;
        scoreText.text = score.ToString();
        
    }

    public void DecreaseHeart(GameObject toDestroy) {
        totalLife--;
        if (totalLife > 0) {
            hearts[heartIndex].GetComponent<Image>().sprite = emptyHeart;
            heartIndex++;
        }
        else {
            Destroy(toDestroy);
        }
        
    }

    public void OpenPanel() {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel() {
        
        panel.LeanScale(Vector3.zero, 0.2f);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
