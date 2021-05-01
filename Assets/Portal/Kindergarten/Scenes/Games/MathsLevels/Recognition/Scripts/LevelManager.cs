using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static bool isPopupOpened = true;
    public static int levelNo = 1;
    public static int numberToGet;
    [SerializeField] private GameObject levelPopup;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI randomNumber;
    private void Start() {
        numberToGet = Random.Range(0, 9);
        randomNumber.text = numberToGet.ToString();
        levelText.text = "Level " + levelNo;
        EnableLevelPopup();
    }

    public void EnableLevelPopup() {
        levelPopup.SetActive(true);
        Time.timeScale = 0f;
        isPopupOpened = true;
    }

    public void DisableLevelPopup() {
        levelPopup.SetActive(false);
        Time.timeScale = 1f;
        isPopupOpened = false;
    }
}
