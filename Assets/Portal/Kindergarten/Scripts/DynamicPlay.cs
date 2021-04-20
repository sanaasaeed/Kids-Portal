using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlay : MonoBehaviour {
    private SceneTransition transition;
    public static string sceneName;
    void Start() {
        transition = GetComponent<SceneTransition>();
        transition.scene = sceneName;
    }


}
