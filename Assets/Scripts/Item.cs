using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    //This script is on physical items in the world. When clicked, instantiates an itemCard and puts itself into that card, passing along all its stats, Then deactivates the world object.

    [Header("Stats")]
    public string itemName = "generic item";
    public string itemType = "generic itemtype";
    public string effect = "generic effect";
    public string flavorText = "generic flavortext";
    public int effectDuration = 0;
    public int itemID = 0;
    public Sprite icon;

    [Header("References")]
    public GameObject itemFaces;
    public GameObject itemFacePrefab;

    void Start()
    {
        itemFaces = GameObject.Find("ItemFaces");
    }

    void OnMouseDown()
    {
        //Spawns itemCard with THIS object in it's public GameObject myItem.
        GameObject g = Instantiate(itemFacePrefab);
        g.GetComponent<ItemFace>().myItem = this;
        g.GetComponent<ItemFace>().parentToReturnTo = itemFaces.transform;

        //Deactivates physical object in the world.
        this.gameObject.SetActive(false);
    }
}
