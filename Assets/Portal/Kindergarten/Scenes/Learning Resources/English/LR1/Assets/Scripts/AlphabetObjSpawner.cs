using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetObjSpawner : MonoBehaviour {
    [SerializeField] private List<Sprite> alphabetSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> objectsSpriteList = new List<Sprite>();
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject alphabetPrefab;
    [SerializeField] private GameObject objectPrefab;

    private int roundNo = 0;
    void Start() {
        StartCoroutine(nameof(WaitAndInitialize));
        alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[roundNo];
        objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[roundNo];
    }
    IEnumerator WaitAndInitialize() {
        yield return new WaitForSeconds(4);
        Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
        roundNo += 1;
        nextBtn.SetActive(true);
    }

    public void NextAlphabet() {
        var toBeDestroyedObjects = FindObjectsOfType<GameObject>();
        foreach (var clones in toBeDestroyedObjects) {
            if (clones.name.Contains("Clone")) {
                Destroy(clones);
            }
        }
        alphabetPrefab.GetComponent<SpriteRenderer>().sprite = alphabetSpriteList[roundNo];
        objectPrefab.GetComponent<SpriteRenderer>().sprite = objectsSpriteList[roundNo];
        Instantiate(alphabetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        Instantiate(objectPrefab, new Vector3(-4, 0, -1), Quaternion.identity);
        roundNo += 1;
    }
}  