using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSelection : MonoBehaviour {
    [SerializeField] private List<Sprite> thingsSprites;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemXpos = -6;
    public int noOfThings;
    void Start() {
        DisplayThings();
    }

    private int GetRandomNumber() {
        return Random.Range(1, 5);
    }

    public void DisplayThings() {
        noOfThings = GetRandomNumber();
        Sprite randomSprite = thingsSprites[Random.Range(0, thingsSprites.Count)];
        int xPosChange = -3;
        for (int i = 0; i < noOfThings; i++) {
            xPosChange += 4;
            itemPrefab.GetComponent<SpriteRenderer>().sprite = randomSprite;
            Instantiate(itemPrefab, new Vector3(itemXpos + xPosChange, 0, -1), quaternion.identity);
            
        }
    }
    public void DestroyItems() {
        var items = GameObject.FindGameObjectsWithTag("item");
        foreach (var item in items) {
            Destroy(item);
        }
    }
}
