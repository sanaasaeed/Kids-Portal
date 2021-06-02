using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class levelUnlocker : MonoBehaviour {
    [SerializeField] public List<GameObject> lrLevelBtns;
    [SerializeField] public List<GameObject> gameLevelBtns;
    [SerializeField] private string lrPlayerPref;
    [SerializeField] private string gamePlayerPref;
    private RewardCollector rewardCollector;
    
    private void Start() {
        // StartCoroutine(AddRewardCard(1));
       int currentLRLevel = PlayerPrefs.GetInt(lrPlayerPref, 0);
        int currentGameLevel = PlayerPrefs.GetInt(gamePlayerPref, 0);
        UnlockGame(currentLRLevel);
        if (currentGameLevel > 0) {
            UnlockLearningResource(currentGameLevel);
        }
       // StartCoroutine(GetRewardCard());
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
            /*lrLevelBtns[i].transform.GetChild(3).transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;*/
        }
    }
    
    IEnumerator GetRewardCard() {
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
            print(learningObject);*/
        }
    }
    
    IEnumerator AddRewardCard(int cardNo) {
        WWWForm form = new WWWForm();
        form.AddField("card", cardNo);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "addRewardCard", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Game Data Submitted successfully " + webRequest.downloadHandler.text);
        }
    }

}
