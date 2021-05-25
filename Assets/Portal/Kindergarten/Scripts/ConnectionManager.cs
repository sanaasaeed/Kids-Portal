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
        SubmitData();
    }
    public void SubmitData() {
        StartCoroutine(HandleDataSend("Sana Saeed", 22));
    }

    IEnumerator HandleDataSend(string name, int age) {
        WWWForm form = new WWWForm();
        // Add here more and more fields and yeah done
        form.AddField("name", name);
        form.AddField("age", age);
        UnityWebRequest webRequest = UnityWebRequest.Post(WebServices.mainUrl + "data", form);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError || webRequest.isHttpError) {
            Debug.Log(webRequest.error);
        }
        else {
            Debug.Log("Submitted successfully " + webRequest.downloadHandler.text);
        }
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
            // Debug.Log(kid.kidName);
        }
    }

    public class Kid {
        public string kidName;
        public string kidAge;
        public string experiencePoints;
        
    }
}
