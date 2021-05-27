using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviour {
    [SerializeField] private Text usernameText;
    private void Start() {
        StartCoroutine(GetSignInInfo());
        SaveManager.Instance.SaveAllPlayerPrefsToDatabase();
        SaveManager.Instance.UpdateExperiencePoints(80);
    }
    

    IEnumerator GetSignInInfo() {
        UnityWebRequest webRequest = UnityWebRequest.Get(WebServices.mainUrl + "connectunity");
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully Data: " + webRequest.downloadHandler.text);
            Kid kid = JsonUtility.FromJson<Kid>(webRequest.downloadHandler.text);
            usernameText.text = kid.kidName;
            Debug.Log(kid.kidID);
            // Debug.Log(kid.kidName);
        }
    }

    public class Kid {
        public string kidName;
        public string kidAge;
        public string experiencePoints;
        public string kidID;
    }
}
