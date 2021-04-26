using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlphabetObjSpawner : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> objectsSpriteList = new List<Sprite>();
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private GameObject instructionPopup;
    [SerializeField] private GameObject playActivityBtn;
    [SerializeField] private GameObject canvas;
    private int rounds = 4;
    private int roundNo = 0;
    private static int alphabetNo = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        if (ActivityManager.isStart) {
            StartCoroutine(nameof(WaitAndInitialize));
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[alphabetNo];
            objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[alphabetNo];  
        }
        else {
            // TODO: Disable repeat with us
            instructionPopup.SetActive(false);
            NextAlphabet();
        }
        
    }
    IEnumerator WaitAndInitialize() {
        yield return new WaitForSeconds(4);
        Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
        alphabetNo += 1;
        nextBtn.SetActive(true);
    }

    public void NextAlphabet() {
        nextBtn.SetActive(true);
        DestroyAlphabets();
        
        if (alphabetNo < alphabetSpriteList.Count) {
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[alphabetNo];
            objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[alphabetNo];
            Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
            Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
            alphabetNo += 1;
            Debug.Log("Alphabet No in Next alphabet flow " + alphabetNo);
        }
        else {
            Debug.Log("LAST ACTIVITY HERE");
            nextBtn.SetActive(false);   // TODO: WIn Screen
            Debug.Log("Learning Resource completed Game Unlocked");
        }
        
        if (alphabetNo % rounds == 0) {
            var createdBtn = Instantiate(playActivityBtn, canvas.transform, true);
            var rectTransform = createdBtn.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(-700, 50, 0);
        }
    }

    public void Play() {
        if (alphabetNo % rounds == 0) {
            roundNo += 1;
            Debug.Log("Insert activity here" + roundNo);
            Debug.Log("Alphabet No: " + alphabetNo);
            SceneManager.LoadScene("EmbeddedActivity");
        }
    }
    
    void DestroyAlphabets() {
        var toBeDestroyedObjects = FindObjectsOfType<GameObject>();
        foreach (var clones in toBeDestroyedObjects) {
            if (clones.name.Contains("Clone")) {
                Destroy(clones);
            }
        }
    }

    public void PlayActivity() {
        int activityAlphabet = alphabetNo;
        for (int i = 0; i < rounds; i++) {
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[activityAlphabet];
            var clonedObj = Instantiate(alphabetPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            activityAlphabet -= 1;
        }
    }
}  