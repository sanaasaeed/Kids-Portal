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

    public void LoadAllPlayerPrefs() {
        StartCoroutine(GetProgress());
    }

    // To be called while saving player prefs in any game or LR
    public void SaveAllPlayerPrefsToDatabase() {
        StartCoroutine(UpdatePlayerPrefs());
    }

    public void UpdateExperiencePoints(int pointsToAdd) {
        experiencePoints += pointsToAdd;
        StartCoroutine(SaveToDatabase("experiencePoints", experiencePoints, "updatexp"));
    }

    IEnumerator SaveToDatabase(string key, int value, string url) {
        WWWForm form = new WWWForm();
        form.AddField(key, value);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + url, form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully " + webRequest.downloadHandler.text);
        }
    }
    IEnumerator UpdatePlayerPrefs() {
        WWWForm form = new WWWForm();
        form.AddField("engGamesProgress", PlayerPrefs.GetInt("engGameLevel", 0));
        form.AddField("mathGamesProgress", PlayerPrefs.GetInt("gameMathLevel", 0));
        form.AddField("urduGamesProgress", PlayerPrefs.GetInt("urduGameLevel", 0));
        form.AddField("engLrProgress", PlayerPrefs.GetInt("lrLevelEng", 0));
        form.AddField("mathLrProgress", PlayerPrefs.GetInt("lrMathLevel", 0));
        form.AddField("urduLrProgress", PlayerPrefs.GetInt("lrUrduLevel", 0));
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "progress", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully " + webRequest.downloadHandler.text);
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
    
    IEnumerator GetProgress() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "progress");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            Progress progress = JsonUtility.FromJson<Progress>(webRequest.downloadHandler.text);
            progress.SetPlayerPrefsFromDb("lrLevelEng", progress.engLrProgress);
            progress.SetPlayerPrefsFromDb("lrMathLevel", progress.mathLrProgress);
            progress.SetPlayerPrefsFromDb("lrUrduLevel", progress.urduLrProgress);
            progress.SetPlayerPrefsFromDb("engGameLevel", progress.engGamesProgress);
            progress.SetPlayerPrefsFromDb("gameMathLevel", progress.mathGamesProgress);
            progress.SetPlayerPrefsFromDb("urduGameLevel", progress.urduGamesProgress);
            
        }
    }

    public void SaveLRData(string subject, string name, int status, string learningTime) {
        StartCoroutine(SaveLRDataToDB(subject, name, status, learningTime));
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


