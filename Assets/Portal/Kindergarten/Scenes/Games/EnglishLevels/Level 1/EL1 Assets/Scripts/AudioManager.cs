using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource correctAudio;
    [SerializeField] private AudioSource wrongAudio;

    public  void PlayCorrectAudio() {
        correctAudio.Play();
    }

    public void PlayWrongAudio() {
        wrongAudio.Play();
    }
}
