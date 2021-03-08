using UnityEngine;

public class DisplayLetter : MonoBehaviour
{
    [SerializeField] bool upperCase;
    internal void SetLetter(char originalLetter) {
        if (upperCase) {
            GetComponent<TMPro.TMP_Text>().text = originalLetter.ToString().ToUpper();
        }
        else {
            GetComponent<TMPro.TMP_Text>().text = originalLetter.ToString().ToLower();
        }
        
        
    }
}
