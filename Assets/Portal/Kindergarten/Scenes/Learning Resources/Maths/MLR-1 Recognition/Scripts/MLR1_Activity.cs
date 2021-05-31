using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLR1_Activity : MonoBehaviour {
    [SerializeField] private List<GameObject> numbers;
    private MLR1 mainScript;
    private AudioSource audioSrc;
    [HideInInspector] public Sprite randomSprite;
    [SerializeField] public List<AudioClip> rightWrongAudios;
    public GameObject cameraGameObject;
    [HideInInspector] public AudioSource cameraAudioSrc;
    
    void Start() {
        cameraAudioSrc = cameraGameObject.GetComponent<AudioSource>();
        audioSrc = GetComponent<AudioSource>();
        mainScript = FindObjectOfType<MLR1>();
        int randomIndex = Random.Range(MLR1.letterNo - 3, MLR1.letterNo);
        randomSprite = mainScript.mathLetters[randomIndex];
        numbers[Random.Range(0, numbers.Count)].GetComponent<SpriteRenderer>().sprite = randomSprite;
        StartCoroutine(Wait(randomIndex));
        foreach (var number in numbers) {
            if (number.GetComponent<SpriteRenderer>().sprite != randomSprite) {
                number.GetComponent<SpriteRenderer>().sprite = mainScript.mathLetters[Random.Range(0, mainScript.mathLetters.Count)];
            }
        }
    }

    IEnumerator Wait(int index) {
        yield return new WaitForSeconds(0.5f);
        audioSrc.PlayOneShot(mainScript.audios[index]);
    }
}
