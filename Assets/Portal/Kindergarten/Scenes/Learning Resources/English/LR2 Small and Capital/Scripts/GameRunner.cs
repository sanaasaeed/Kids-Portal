using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour {
    [SerializeField] private List<Sprite> capitalAlphabets;
    [SerializeField] private List<Sprite> smallAlphabets;
    [SerializeField] private GameObject capitalPrefab;
    [SerializeField] private GameObject smallPrefab;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioClip capitalAudioClip;
    [SerializeField] private AudioClip smallAudioClip;
    
    private Animation m_anim;
    public static int alphabetNo = 0;
    private AudioSource m_smallAlpAudioSource, m_capitalAlpAudioSource;
    public static int checkPoint;
   // public static int prevCheckpoint = -4;
    private GameObject capitalAlphabet;
    private GameObject smallAlphabet;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        capitalAlphabet = GameObject.Find("Capital Alphabet");
        smallAlphabet = GameObject.Find("Small Alphabet");
        m_smallAlpAudioSource = smallPrefab.GetComponent<AudioSource>();
        m_capitalAlpAudioSource = capitalPrefab.GetComponent<AudioSource>();
        capitalAlphabet.GetComponent<SpriteRenderer>().sprite = capitalAlphabets[alphabetNo];
        smallAlphabet.GetComponent<SpriteRenderer>().sprite = smallAlphabets[alphabetNo];
        StartCoroutine(nameof(PlaySound));
    }

    public void NextBtn() {
        if (alphabetNo < capitalAlphabets.Count) {
            capitalAlphabet.GetComponent<SpriteRenderer>().sprite = capitalAlphabets[alphabetNo+1];
            capitalAlphabet.GetComponent<Animator>().Play("Capital animation", -1, 0f);
            Debug.Log("Inside if: "+ (alphabetNo + 1));
            smallAlphabet.GetComponent<Animator>().Play("small alphabet", -1, 0f);
            smallAlphabet.GetComponent<SpriteRenderer>().sprite = smallAlphabets[alphabetNo + 1];
            StartCoroutine(nameof(PlaySound));
            alphabetNo++;
        }
        else {
            Debug.Log("Display WIN screen");
        }

        if (alphabetNo % 4 == 0) {
            checkPoint = alphabetNo;
            //prevCheckpoint = checkPoint;
            //Debug.Log(prevCheckpoint + "prev");
            SceneManager.LoadScene($"EmbeddedActivity2");
            Debug.Log(alphabetNo);
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
