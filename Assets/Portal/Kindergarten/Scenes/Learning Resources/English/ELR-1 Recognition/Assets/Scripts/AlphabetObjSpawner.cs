using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class AlphabetObjSpawner : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> objectsSpriteList = new List<Sprite>();
    [SerializeField] private List<AudioClip> audioClipList = new List<AudioClip>();
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private GameObject instructionPopup;
    [SerializeField] private GameObject playActivityBtn;
    [SerializeField] private GameObject canvas;
    private levelUnlocker lockHandler;
    private ActivityManager m_activityManager;
    private AudioSource alphabetAudio;
    private Animator alphabetAnimator;
    private Animator objAnimator;
    private int rounds = 4;
    public static float levelTimer = 0;
    public static bool isTimerRunning = true;
    public static int alphabetNo = 0;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        PlayerPrefs.SetInt("currEngLevelNo", 1);
        PlayerPrefs.Save();
        lockHandler = FindObjectOfType<levelUnlocker>();
        m_activityManager = FindObjectOfType<ActivityManager>();
        alphabetAnimator = alphabetPrefab.GetComponent<Animator>();
        objAnimator = objectPrefab.GetComponent<Animator>();
        alphabetAudio = alphabetPrefab.GetComponent<AudioSource>();
        if (ActivityManager.isStart) {
            alphabetAnimator.enabled = true;
            objAnimator.enabled = true;
            StartCoroutine(nameof(WaitAndInitialize));
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[alphabetNo];
            objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[alphabetNo];
            alphabetAudio.clip = audioClipList[alphabetNo];
            alphabetAudio.Play();
        }
        else {
            alphabetAudio.enabled = true;
            instructionPopup.SetActive(false);
            NextAlphabet();
        }
        
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
    }
    
    IEnumerator WaitAndInitialize() {
        yield return new WaitForSeconds(4);
        instructionPopup.SetActive(false);
        Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
        alphabetNo += 1;
        nextBtn.SetActive(true);
    }

    public void NextAlphabet() {
        alphabetAnimator.enabled = true;
        objAnimator.enabled = true;
        nextBtn.SetActive(true);
        DestroyAlphabets();
        
        if (alphabetNo < alphabetSpriteList.Count) {
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[alphabetNo];
            objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[alphabetNo];
            alphabetAudio.clip = audioClipList[alphabetNo];
            alphabetAudio.Play();
            Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
            Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
            alphabetNo += 1;
        }
        else {
            nextBtn.SetActive(false);  
            // Finish the Game
            FinishResource();
        }
        
        if (alphabetNo % rounds == 0) {
            nextBtn.SetActive(false);
            var createdBtn = Instantiate(playActivityBtn, canvas.transform, true);
            var rectTransform = createdBtn.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(-700, 50, 0);
        }
    }

    public void Play() {
        if (alphabetNo % rounds == 0) {
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

    public void FinishResource() {
        isTimerRunning = false;
        Debug.Log(levelTimer);
        PlayerPrefs.SetInt("lrLevelEng", 1);
        PlayerPrefs.Save();
        SaveManager.Instance.SaveAllPlayerPrefsToDatabase();
        SaveManager.Instance.SaveLRData("English", "Alphabet Recogition", 1, levelTimer.ToString());
        SceneManager.LoadScene("SubjectSelect");
        Destroy(gameObject);
        Debug.Log("Learning Resource completed Game Unlocked");
    }

    /*public void PlayAlphabetAndObjActivity() {
        alphabetAudio.enabled = false;
        alphabetAnimator.enabled = false;
        objAnimator.enabled = false;
        int activityAlphabet = alphabetNo;
        int posIncrease = 4;
        for (int i = 0; i < rounds; i++) {
            alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[activityAlphabet-1];
            objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[activityAlphabet-1];
            var clonedAlphabet = Instantiate(alphabetPrefab, new Vector3(-10 + posIncrease, 2, -1), Quaternion.identity);
            var clonedObj = Instantiate(objectPrefab, new Vector3(-10 + posIncrease, -2, -1), Quaternion.identity);
            clonedAlphabet.transform.localScale -= new Vector3(0.08f, 0.08f, 0);
            clonedObj.transform.localScale -= new Vector3(0.2f, 0.2f, 0);
            activityAlphabet -= 1;
            posIncrease += 4;
        }
    }*/
    
    
    public List<Sprite> ReturnAlphabetList() {
        
        List<Sprite> activityAlphabetList = new List<Sprite>();
        int activityAlphabet = alphabetNo;
        for (int i = 0; i < 4; i++) {
            var alphabetSprite = alphabetSpriteList[activityAlphabet - 1];
            activityAlphabetList.Add(alphabetSprite);
            activityAlphabet -= 1;
        }
        return activityAlphabetList;
    }
}  