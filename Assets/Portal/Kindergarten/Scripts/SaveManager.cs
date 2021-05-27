using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance;
    public int experiencePoints;
    public int engGamesProgress;
    public int mathGamesProgress;
    public int urduGamesProgress;
    public int engLrProgress;
    public int mathLrProgress;
    public int urduLrProgress;
    private void Awake() {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            PlayerPrefs.DeleteAll();
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
    

    public void LoadAllPlayerPrefs() {
        //Load here all of them and then set them
    }

    // To be called while saving player prefs in any game or LR
    public void SaveAllPlayerPrefsToDatabase() {
        engGamesProgress = PlayerPrefs.GetInt("engGameLevel", 0);
        mathGamesProgress = PlayerPrefs.GetInt("gameMathLevel", 0);
        urduGamesProgress = PlayerPrefs.GetInt("engGameLevel", 0);
        engLrProgress = PlayerPrefs.GetInt("lrLevelEng", 0);
        mathLrProgress = PlayerPrefs.GetInt("lrMathLevel", 0);
        urduLrProgress = PlayerPrefs.GetInt("lrUrduLevel", 0);
        StartCoroutine(UpdatePlayerPrefs());
    }

    public void UpdateExperiencePoints(int pointsToAdd) {
        experiencePoints += pointsToAdd;
        StartCoroutine(SaveToDatabase("experiencePoints", experiencePoints));
    }

    IEnumerator SaveToDatabase(string key, int value) {
        WWWForm form = new WWWForm();
        form.AddField(key, value);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "data", form);
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
        form.AddField("engGamesProgress", engGamesProgress);
        form.AddField("mathGamesProgress", mathGamesProgress);
        form.AddField("urduGamesProgress", urduGamesProgress);
        form.AddField("engLrProgress", engLrProgress);
        form.AddField("mathLrProgress", mathLrProgress);
        form.AddField("urduLrProgress", urduLrProgress);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "data", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully " + webRequest.downloadHandler.text);
        }
    }
}

