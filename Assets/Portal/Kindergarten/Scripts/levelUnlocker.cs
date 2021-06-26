using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class levelUnlocker : MonoBehaviour {
    [SerializeField] public List<GameObject> lrLevelBtns;
    [SerializeField] public List<GameObject> gameLevelBtns;
    [SerializeField] public string subject;

    private void Start() {
        StartCoroutine(ReceiveProgress());
    }

    public void UnlockGame(int currentLrLevel) {
        for (int i = 0; i < currentLrLevel; i++) {
            gameLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            gameLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void UnlockLearningResource(int currentGameLevel) {
        for (int i = 0; i <= currentGameLevel; i++) {
            lrLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            lrLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    IEnumerator ReceiveProgress() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "sendProgress");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data" );
            JSONNode progress = JSONNode.Parse(webRequest.downloadHandler.text);
            foreach (var prog in progress) {
                Debug.Log(progress);
            }
            int engLrProgress = progress[0]["engLrProgress"];
            int engGameProgress = progress[0]["engGamesProgress"];
            int mathGamesProgress = progress[0]["mathGamesProgress"];
            int urduGamesProgress = progress[0]["urduGamesProgress"];
            int mathLrProgress = progress[0]["mathLrProgress"];
            int urduLrProgress = progress[0]["urduLrProgress"];

            if (subject == "English") {
                UnlockGame(engLrProgress);
                UnlockLearningResource(engGameProgress);
            } else if (subject == "Urdu") {
                UnlockGame(urduLrProgress);
                UnlockLearningResource(urduGamesProgress);
            } else if (subject == "Maths") {
                UnlockGame(mathLrProgress);
                UnlockLearningResource(mathGamesProgress);
            }
            
        }
    }
}
