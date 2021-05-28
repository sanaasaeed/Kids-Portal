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
    public static ConnectionManager Instance;
    private Kid kid;
    private void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy (gameObject);
        }
    }

    private void Start() {
        StartCoroutine(GetSignInInfo(kid));
    }

    public void GetKidInfo() {
        StartCoroutine(GetKidInfo(kid));
    }

    IEnumerator GetKidInfo(Kid kidData) {
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
    }
    IEnumerator GetSignInInfo(Kid kidData) {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            kidData = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            usernameText.text = kidData.kidName;
            Debug.Log(kidData.kidID);
            experiencePointsText.text = "XP: " + kidData.experiencePoints;
            yield return kidData;
        }
    }
}

public class Kid {
    public static readonly  Kid kidInstance  = new Kid();

    private Kid() {
    }
    public string kidName;
    public string kidAge;
    public string experiencePoints;
    public string kidID;
}