using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBullet : MonoBehaviour {
    public float speed = 4f;
    private WordSpawner wordSpawner;
    private AudioSource audioSrc;
    public AudioClip wrongAudioClip;

    private void Start() {
        wordSpawner = FindObjectOfType<WordSpawner>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update() {
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        wordSpawner.totalBulletsHit++;
        if (wordSpawner.wordsAns[WordSpawner.indexNo].Contains(other.GetComponent<SpriteRenderer>().sprite.name.ToLower())) {
            other.gameObject.SetActive(false);
            wordSpawner.fillInWordText.text = wordSpawner.wordsAns[WordSpawner.indexNo];
            wordSpawner.totalScore++;
            audioSrc.Play();
            StartCoroutine(WaitAndDo(other));
        }
        else {
            audioSrc.PlayOneShot(wrongAudioClip);
            wordSpawner.totalScore--;
        }
    }

    IEnumerator WaitAndDo(Collider2D other) {
        if (WordSpawner.indexNo < wordSpawner.words.Count) {
            WordSpawner.indexNo++;
        }
        yield return new WaitForSeconds(0.5f);
        other.gameObject.SetActive(true);
        wordSpawner.DisplayTextAndImage();
    }
}
