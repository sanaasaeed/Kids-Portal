using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardCollector : MonoBehaviour {
    public static RewardCollector Instance;
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else if (Instance != this) {
            Destroy (gameObject);
        }
    }
    private void Start() {
        
    }
    
    
        
        /*else if (experiencePoints > 170 && experiencePoints < 254) {
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
        }*/
    
    
    

    

    

}
