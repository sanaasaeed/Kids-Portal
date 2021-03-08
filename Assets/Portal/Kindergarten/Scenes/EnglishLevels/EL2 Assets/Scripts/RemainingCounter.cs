using TMPro;
using UnityEngine;

public class RemainingCounter : MonoBehaviour {

    public void SetRemaining(int remaining) {
        GetComponent<TMP_Text>().text = "x" + remaining;
    }
}
