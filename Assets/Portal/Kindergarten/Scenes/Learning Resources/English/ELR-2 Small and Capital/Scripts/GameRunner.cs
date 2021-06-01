using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour {
    [SerializeField] public List<Sprite> capitalAlphabets;
    [SerializeField] private List<Sprite> smallAlphabets;
    [SerializeField] private GameObject capitalPrefab;
    [SerializeField] private GameObject smallPrefab;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioClip capitalAudioClip;
    [SerializeField] private AudioClip smallAudioClip;
    private float levelTimer= 0;
    private bool isTimerRunning = true;
    private Animation m_anim;
    public static int alphabetNo = 0;
    public static int interval = 4;
    private AudioSource m_smallAlpAudioSource, m_capitalAlpAudioSource;
    public static int checkPoint;
    private GameObject m_capitalAlphabet;
    private GameObject m_smallAlphabet;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        m_capitalAlphabet = GameObject.Find("Capital Alphabet");
        m_smallAlphabet = GameObject.Find("Small Alphabet");
        m_smallAlpAudioSource = smallPrefab.GetComponent<AudioSource>();
        m_capitalAlpAudioSource = capitalPrefab.GetComponent<AudioSource>();
        m_capitalAlphabet.GetComponent<SpriteRenderer>().sprite = capitalAlphabets[alphabetNo];
        m_smallAlphabet.GetComponent<SpriteRenderer>().sprite = smallAlphabets[alphabetNo];
        StartCoroutine(nameof(PlaySound));
    }

    private void Update() {
        if (isTimerRunning) {
            levelTimer += Time.deltaTime;
        }
    }

    public void NextBtn() {
        int newAlphabetNo = alphabetNo + 1;
        if (newAlphabetNo < capitalAlphabets.Count) {
            Debug.Log(newAlphabetNo);
            Debug.Log("Total " + capitalAlphabets.Count);
            m_capitalAlphabet.GetComponent<SpriteRenderer>().sprite = capitalAlphabets[newAlphabetNo];
            m_capitalAlphabet.GetComponent<Animator>().Play("Capital animation", -1, 0f);
            m_smallAlphabet.GetComponent<Animator>().Play("small alphabet", -1, 0f);
            m_smallAlphabet.GetComponent<SpriteRenderer>().sprite = smallAlphabets[newAlphabetNo];
            StartCoroutine(nameof(PlaySound));
            alphabetNo++;
        }
        else {
            isTimerRunning = false;
            Debug.Log("Display WIN screen");
            PlayerPrefs.SetInt("lrLevelEng", 2);
            PlayerPrefs.Save();
            /*SaveManager.Instance.SaveLRData("English", "Capital and Small Alphabets", 1,levelTimer.ToString());
            SaveManager.Instance.UpdateExperiencePoints(20);
            SaveManager.Instance.SaveProgressData("English", "lr", 2);*/
            SceneManager.LoadScene("English");
            alphabetNo = 0;
        }

        if (alphabetNo % interval == 0 && alphabetNo != 0) {
            checkPoint = alphabetNo;
            SceneManager.LoadScene($"EmbeddedActivity2");
        }
    }

    IEnumerator PlaySound() {
            m_capitalAlpAudioSource.PlayOneShot(capitalAudioClip);
            yield return new WaitForSeconds(0.5f);
            m_capitalAlpAudioSource.PlayOneShot(audioClips[alphabetNo]);
            yield return new WaitForSeconds(0.8f);
            m_smallAlpAudioSource.PlayOneShot(smallAudioClip);
            yield return new WaitForSeconds(0.5f);
            m_smallAlpAudioSource.PlayOneShot(audioClips[alphabetNo]);
        }
    
    public void RepeatBtn() {
        alphabetNo--;
        NextBtn();
    }
}
