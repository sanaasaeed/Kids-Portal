using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance;
    public int experiencePoints;
    private void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy (gameObject);
        }
    }
    
    IEnumerator SaveGameDataToDB(string subject, string gameTitle, int gameScore, string gameTime, int experiencePoints, int gameStatus) {
        WWWForm form = new WWWForm();
        form.AddField("subject", subject);
        form.AddField("gameTitle", gameTitle);
        form.AddField("gameScore", gameScore);
        form.AddField("gameTime", gameTime);
        form.AddField("experiencePoints", experiencePoints);
        form.AddField("gameStatus", gameStatus);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "add-game-score", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Game Data Submitted successfully " + webRequest.downloadHandler.text);
        }
    }

    public void SaveGameData(string subject, string gameTitle, int gameScore, string gameTime, int experiencePoints, int gameStatus) {
        StartCoroutine(SaveGameDataToDB(subject, gameTitle, gameScore, gameTime, experiencePoints, gameStatus));
    }
    
    IEnumerator SaveLRDataToDB(string subject, string name, int status, string learningTime){
        WWWForm form = new WWWForm();
        form.AddField("subject", subject);
        form.AddField("name", name);
        form.AddField("status", status);
        form.AddField("learningTime", learningTime);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "add-lr-data", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Game Data Submitted successfully " + webRequest.downloadHandler.text);
        //    var fromjson = JsonUtility.FromJson<Player>(webRequest.downloadHandler.text);
        }
    }
    

    public void SaveLRData(string subject, string name, int status, string learningTime) {
        StartCoroutine(SaveLRDataToDB(subject, name, status, learningTime));
    }

    public void SaveProgressData(string subject, string type, int progress) {
        if (subject == "English" && type == "lr") {
            StartCoroutine(SaveEngLrProgress(progress));
        } else if (subject == "English" && type == "game") {
            StartCoroutine(SaveEngGameProgress(progress));
        } else if (subject == "Urdu" && type == "lr") {
            StartCoroutine(SaveUrduLrProgress(progress));
        } else if (subject == "Urdu" && type == "game") {
            StartCoroutine(SaveUrduGameProgress(progress));
        } else if (subject == "Math" && type == "lr") {
            StartCoroutine(SaveMathLrProgress(progress));
        } else if (subject == "Math" && type == "game") {
            StartCoroutine(SaveMathGameProgress(progress));
        }
    }
    IEnumerator SaveEngLrProgress(int progress) {
        WWWForm form = new WWWForm();
        form.AddField("engLrProgress", progress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getEngLrProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("English Progress Submitted successfully ");
            
        }
    }

    IEnumerator SaveEngGameProgress(int gameProgress) {
        WWWForm form = new WWWForm();
        form.AddField("engGamesProgress", gameProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getEngGameProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("English Progress Submitted successfully ");
            
        }
    }

    IEnumerator SaveMathGameProgress(int gameProgress) {
        WWWForm form = new WWWForm();
        form.AddField("mathGamesProgress", gameProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getMathGameProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Math Progress Submitted successfully ");
        }
    }
    
    IEnumerator SaveMathLrProgress(int gameProgress) {
        WWWForm form = new WWWForm();
        form.AddField("mathLrProgress", gameProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getMathLrProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Math Progress Submitted successfully ");
            
        }
    }

    IEnumerator SaveUrduGameProgress(int gameProgress) {
        WWWForm form = new WWWForm();
        form.AddField("urduGamesProgress", gameProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getUrduGameProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Urdu Progress Submitted successfully ");
        }
    }

    IEnumerator SaveUrduLrProgress(int gameProgress) {
        WWWForm form = new WWWForm();
        form.AddField("urduLrProgress", gameProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "getUrduLrProgress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Urdu Progress Submitted successfully ");
            
        }
    }
    
}

class Progress {
    public int engGamesProgress;
    public int mathGamesProgress;
    public int urduGamesProgress;
    public int engLrProgress;
    public int mathLrProgress;
    public int urduLrProgress;

    public void SetPlayerPrefsFromDb(string key, int value) {
        PlayerPrefs.SetInt(key, value);
    }
}


