using System.Collections;
using TMPro;
using UnityEngine;

public class ClickHandler : MonoBehaviour {
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private TMP_Text buttonText;
    private ScoreHandler scoreHandler;
    private RandomSelection randomSelection;
    void Start() {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        randomSelection = gameManager.GetComponent<RandomSelection>();
    }
    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
    public void HandleClick() {
        int noOfThings = randomSelection.noOfThings;
        if (buttonText.text == noOfThings.ToString()) {
            randomSelection.DestroyItems();
            randomSelection.DisplayThings();
            scoreHandler.IncreaseScore();
        }
        else if(buttonText.text != noOfThings.ToString()){
            panel.SetActive(true);
            StartCoroutine(nameof(WaitAndDestroy));
            scoreHandler.DecreaseScore();
        }
    }
}
