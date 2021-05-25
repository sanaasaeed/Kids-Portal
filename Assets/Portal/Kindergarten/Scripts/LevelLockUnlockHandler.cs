using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLockUnlockHandler : MonoBehaviour {
    [SerializeField] public List<GameObject> engLevelButtons;
    [SerializeField] public List<GameObject> urduLevelButtons;
    [SerializeField] public List<GameObject> mathLevelButtons;
    
    public static LevelLockUnlockHandler Instance;

    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
    void Start() {
        PlayerPrefs.SetInt("engLevelNo", 1);
        PlayerPrefs.SetInt("urduLevelNo", 1);
        PlayerPrefs.SetInt("mathLevelNo", 1);
    }

    public void UnlockLevel(string subject) {
        if (subject.ToLower().Contains("english")) {
            int  currentLevelNo = PlayerPrefs.GetInt("engLevelNo");
            engLevelButtons[currentLevelNo - 1].GetComponent<AnimatedButton>().interactable = true;
            //englLevelButtons[currentLevelNo - 1]
        } else if (subject.ToLower().Contains("maths")) {
           int currentLevelNo = PlayerPrefs.GetInt("urduLevelNo");
            engLevelButtons[currentLevelNo - 1].GetComponent<AnimatedButton>().interactable = true;
        }
        else {
           int currentLevelNo = PlayerPrefs.GetInt("mathLevelNo");
            engLevelButtons[currentLevelNo - 1].GetComponent<AnimatedButton>().interactable = true;
        }
        
    }
    
}
