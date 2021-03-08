using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ClickLetters : MonoBehaviour, IPointerClickHandler
{
    private char _randomLetter;
    private bool _uppercase;
    private AudioSource _audioSource;
    [SerializeField] AudioClip audioClip;

    private void OnEnable() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log($"CLick on letter {_randomLetter}");
        if(_randomLetter == GameController.Instance.OriginalLetter) {
            GetComponent<TMP_Text>().color = Color.cyan;
            enabled = false;
            GameController.Instance.HandleCorrectLetterClick(_uppercase);
        }
        else {
        }
    }

    internal void SetLetter(char letter) {
        enabled = true;
        GetComponent<TMP_Text>().color = Color.white;
        _randomLetter = letter;
        if (Random.Range(0, 100) > 50) {
            _uppercase = false;
            GetComponent<TMP_Text>().text = _randomLetter.ToString().ToLower();
        }
        else {
            _uppercase = true;
            GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
        }
    }
}
