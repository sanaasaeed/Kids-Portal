using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMeasure : MonoBehaviour {
    public static TimeMeasure Instance;
   public float levelTimer = 0;
   public bool isTimeRunning = true;
   
   private void Awake() {
           if (Instance == null) {
               DontDestroyOnLoad(gameObject);
               Instance = this;
           }
           else if (Instance != this) {
               Destroy (gameObject);
           }
   }

   public void Update() {
       if (isTimeRunning) {
           levelTimer += Time.deltaTime;
       }
   }

   public float FinishAndReturnTime() {
       isTimeRunning = false;
       return levelTimer;
   }

   public void DestroyYourSelf() {
       Destroy(gameObject);
   }
}
