using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RewardManagr : MonoBehaviour {
    [SerializeField] private GameObject rewardCardPanel;
    [SerializeField] private Image cardImg;
    [SerializeField] private List<Sprite> cards;

    private void Start() {
        StartCoroutine(GetXp());
    }

    public void RewardCard(int experiencePoints, int cardNoFromDb) {
        Debug.Log(("card No From DB: " + cardNoFromDb));
        if (experiencePoints > 85 && experiencePoints < 170 && cardNoFromDb != 1) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[0];
            StartCoroutine(PushCardInDb(0));
        } else if (experiencePoints > 170 && experiencePoints < 254 && cardNoFromDb != 2) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[1];
            StartCoroutine(PushCardInDb(1));
        } else if (experiencePoints > 254 && experiencePoints < 350 && cardNoFromDb != 3) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[2];
            StartCoroutine(PushCardInDb(2));
        } else if (experiencePoints > 350 && experiencePoints < 420 && cardNoFromDb != 4) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[3];
            StartCoroutine(PushCardInDb(3));
        } else if (experiencePoints > 420 && cardNoFromDb != 5) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[4];
            StartCoroutine(PushCardInDb(4));
        }
        Debug.Log("Sending reward data to unity");
    }

    IEnumerator GetXp() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "getxp");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
          //  JSONNode 
           // JSONNode xp = JSON.Parse(webRequest.downloadHandler.text);
            int xp = Int32.Parse(webRequest.downloadHandler.text);
            Debug.Log("XP From Reward Manager: " + xp);
            
            UnityWebRequest getwebrequest = UnityWebRequest.Get(WebServices.mainUrl + "getRewardCard");
            yield return getwebrequest.SendWebRequest();
            if (getwebrequest.isNetworkError || getwebrequest.isHttpError) {
                Debug.Log(getwebrequest.error);
            }
            else {
                Debug.Log("reward data fetched... ");
                int cardNoFromDb = Int32.Parse(getwebrequest.downloadHandler.text);
                Debug.Log("In get card method, CARD NO FROM DB: " + cardNoFromDb);
                RewardCard(xp, cardNoFromDb);
            }
            
            /*JSONNode learningResources = kid["learningResources"];
            JSONNode learningObject = learningResources[0]["subject"].Value;
            print(learningObject);*/
        }
    }
    public void Back() {
        rewardCardPanel.SetActive(false);
    }
    
    IEnumerator PushCardInDb(int cardNo) {
        WWWForm form = new WWWForm();
        form.AddField("cardNo", cardNo);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "saveRewardCard", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("reward data submitted ");
        }
    }
    
    /*IEnumerator GetCard() {
        /*UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "getRewardCard");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("reward data fetched... ");
            cardNoFromDb = Int32.Parse(webRequest.downloadHandler.text);
            Debug.Log("In get card method, CARD NO FROM DB: " + cardNoFromDb);
        }#1#
    }*/
}
