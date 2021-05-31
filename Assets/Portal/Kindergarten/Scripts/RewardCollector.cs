using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardCollector : MonoBehaviour {
    [SerializeField] private Image cardImg;
    [SerializeField] private List<Sprite> cards;
    [SerializeField] private GameObject rewardCardPanel;
    private Kid kid;
    private int experiencePoints;
    private void Start() {
        StartCoroutine(GetXp(kid));
    }
    
    IEnumerator GetXp(Kid kidData) {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            kidData = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            experiencePoints = kidData.experiencePoints;
            RewardCard(experiencePoints);
        }
    }
// TODO: rewards should be put into DB
    public void RewardCard(int experiencePoints){
        if (experiencePoints > 85 && experiencePoints < 170) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[0];
        } else if (experiencePoints > 170 && experiencePoints < 254) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[1];
        } else if (experiencePoints > 254 && experiencePoints < 350) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[2];
        } else if (experiencePoints > 350 && experiencePoints < 420) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[3];
        } else if (experiencePoints > 420) {
            rewardCardPanel.SetActive(true);
            cardImg.sprite = cards[4];
        }
    }

    public void Back() {
        rewardCardPanel.SetActive(false);
    }

    IEnumerator pushCardInDb(string cardNo) {
        WWWForm form = new WWWForm();
        form.AddField("card", cardNo);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "rewards", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Game Data Submitted successfully " + webRequest.downloadHandler.text);
        }
    }
    
    IEnumerator isCardInDb() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            Debug.Log(webRequest.downloadHandler.text);
            /*kidData = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            experiencePoints = kidData.experiencePoints;*/
        }
    }

}
