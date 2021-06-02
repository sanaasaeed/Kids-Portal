using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour {
    [SerializeField] private Text usernameText;
    [SerializeField] private Text experiencePointsText;
   // public static ConnectionManager Instance;
    private Kid kid;


    private void Start() {
        Kid newKid = new Kid();
        StartCoroutine(GetSignInInfo(kid));
        StartCoroutine(GetXp(newKid));
    }

    /*public void GetKidInfo() {
        StartCoroutine(GetKidInfo(kid));
    }*/

    /*IEnumerator GetKidInfo(Kid kidData) {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            kidData = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            Debug.Log(kidData.kidID);
        }
    }*/
    IEnumerator GetSignInInfo(Kid kidData) {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            kidData = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            usernameText.text = kidData.name;
        }
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
            experiencePointsText.text = "XP: " + kidData.experiencePoints;
        }
    }
}

public class Kid {
    public string name;
    public string age;
    public int experiencePoints;
    public string kidID;
}