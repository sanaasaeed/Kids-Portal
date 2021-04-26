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
        
        if (alphabetNo % rounds == 0) { // TODO: when its zero we need to let it go. 
            // btn
            Instantiate(playActivityBtn);
            Play();
        }
    }

    public void Play() {  // TODO: Create a btn programmatically when its time for activity disable next btn and user has to click on play activity btn to play it. 
        
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
            clonedObj.transform.localScale -= new Vector3(1f, 1f, 0);
        }
    }
}  