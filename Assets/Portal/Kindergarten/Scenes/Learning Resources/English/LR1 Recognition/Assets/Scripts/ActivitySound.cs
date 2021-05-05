using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitySound : MonoBehaviour {
    [SerializeField] private AudioClip instructionSound;
    [SerializeField] private List<AudioClip> alphabetAudios;
    public Sprite selectedAlphabet;
    private ActivityManager m_activityManager;
    private AudioSource m_audioSource;
    void Start() {
        m_activityManager = FindObjectOfType<ActivityManager>();
        m_audioSource = GetComponent<AudioSource>();
        StartCoroutine(nameof(AskQuestion));
    }

    public  IEnumerator AskQuestion() {
        m_audioSource.PlayOneShot(instructionSound);
        yield return new WaitForSeconds(1);
        ThrowAlphabet();
    }

    public void ThrowAlphabet() {
        selectedAlphabet = ActivityManager.alphabetList[Random.Range(0, ActivityManager.alphabetList.Count)];
        
        foreach (var audioClip in alphabetAudios) {
            if (selectedAlphabet.name.Contains(audioClip.name)) {
                m_audioSource.PlayOneShot(audioClip);
            }
        }
    }
    
}
