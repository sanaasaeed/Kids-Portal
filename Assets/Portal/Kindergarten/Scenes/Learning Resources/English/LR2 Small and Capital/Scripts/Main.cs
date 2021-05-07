using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    [SerializeField] private List<Sprite> capitalAlphabets;
    [SerializeField] private List<Sprite> smallAlphabets;
    [SerializeField] private GameObject capitalPrefab;
    [SerializeField] private GameObject smallPrefab;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioClip capitalAudioClip;
    [SerializeField] private AudioClip smallAudioClip;
    private Animation m_anim;

    private int m_alphabetNo = 0;
    private AudioSource m_smallAlpAudioSource, m_capitalAlpAudioSource;

    private void Start() {
        m_smallAlpAudioSource = smallPrefab.GetComponent<AudioSource>();
        m_capitalAlpAudioSource = capitalPrefab.GetComponent<AudioSource>();
    }

    public void NextBtn() {
        if (m_alphabetNo < capitalAlphabets.Count) {
            var capitalAlphabet = GameObject.Find("Capital Alphabet");
            var smallAlphabet = GameObject.Find("Small Alphabet");
            capitalAlphabet.GetComponent<SpriteRenderer>().sprite = capitalAlphabets[m_alphabetNo+1];
            capitalAlphabet.GetComponent<Animator>().Play("Capital animation", -1, 0f);
            smallAlphabet.GetComponent<Animator>().Play("small alphabet", -1, 0f);
            smallAlphabet.GetComponent<SpriteRenderer>().sprite = smallAlphabets[m_alphabetNo + 1];
            StartCoroutine(nameof(PlaySound));
            m_alphabetNo++;
        }
        else {
            Debug.Log("Display WIn screen");
        }
        
    }

    IEnumerator PlaySound() {
        Debug.Log("Inside coroutine");
        m_capitalAlpAudioSource.PlayOneShot(capitalAudioClip);
        yield return new WaitForSeconds(0.5f);
        m_capitalAlpAudioSource.PlayOneShot(audioClips[m_alphabetNo]);
        yield return new WaitForSeconds(0.8f);
        m_smallAlpAudioSource.PlayOneShot(smallAudioClip);
        yield return new WaitForSeconds(0.5f);
        m_smallAlpAudioSource.PlayOneShot(audioClips[m_alphabetNo]);
    }

    public void RepeatBtn() {
        m_alphabetNo--;
        NextBtn();
    }
}
