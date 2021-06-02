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
    /*[SerializeField] private string lrPlayerPref;
    [SerializeField] private string gamePlayerPref;*/

    private void Start() {
        StartCoroutine(ReceiveProgress());
        /*int currentLrLevel = 2;
        int currentGameLevel = 1;
        UnlockGame(currentLrLevel);
        UnlockLearningResource(currentGameLevel);*/
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

    /*private void Start() {
       int currentLRLevel = PlayerPrefs.GetInt(lrPlayerPref, 0);
        int currentGameLevel = PlayerPrefs.GetInt(gamePlayerPref, 0);
        UnlockGame(currentLRLevel);
        if (currentGameLevel > 0) {
            UnlockLearningResource(currentGameLevel);
        }
    }

    public void DeleteAllPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }
    
    public void UnlockGame(int currentLevel) {
        for (int i = 0; i < currentLevel; i++) {
            gameLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            gameLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void UnlockLearningResource(int currentLevel) {
        for (int i = 0; i <= currentLevel; i++) {
            lrLevelBtns[i].GetComponent<AnimatedButton>().interactable = true;
            lrLevelBtns[i].transform.GetChild(3).gameObject.SetActive(false);
            /*lrLevelBtns[i].transform.GetChild(3).transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;#1#
        }
    }*/
    
    /*IEnumerator GetRewardCard() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "getRewardCard");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);

            JSONNode cards = JSON.Parse(webRequest.downloadHandler.text);

            foreach (var card in cards) {
                Debug.Log("CARDS " + cards);
            }
            /*JSONNode learningResources = kid["learningResources"];
            JSONNode learningObject = learningResources[0]["subject"].Value;
            print(learningObject);#1#
        }
    }*/
   
}
