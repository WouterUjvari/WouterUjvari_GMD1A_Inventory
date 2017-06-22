using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerExitHandler
{
    //This script is on the main canvas. There is only 1 canvas. 
    public GameObject heldObject = null;
    public GameObject hoverObject = null;
    public GameObject toolTip;
    public GameObject invUI;
    public GameObject spawnParent;
    public bool uiOn;

    public Text itemNamePanel;
    public Text itemTypePanel;
    public Text itemEffectPanel;
    public Text itemTextPanel;
    public Image itemSpritePanel;


    public List<GameObject> shells = new List<GameObject>();
    
    void Update()
    {
        //EZ inv toggle.
        DisplayStats();

        if (Input.GetButtonDown("Inv"))
        {
            uiOn = !uiOn;
        }

        if (uiOn)
        {
            invUI.SetActive(true);
        }
        else
        {
            invUI.SetActive(false);
        }

    }
    public void DisplayStats()
    {
        //Updates turns on the tooltip and updates it with new info from the item script on the item thats in the card that is being held.
        if (heldObject != null)
        {
            itemNamePanel.text = heldObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().itemName;
            itemTypePanel.text = heldObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().itemType;
            itemEffectPanel.text = heldObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().effect;
            itemTextPanel.text = heldObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().flavorText;
            itemSpritePanel.sprite = heldObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().icon;
            toolTip.SetActive(true);
        }
        //Same but for hover.
        else if (hoverObject != null)
        {
            itemNamePanel.text = hoverObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().itemName;
            itemTypePanel.text = hoverObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().itemType;
            itemEffectPanel.text = hoverObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().effect;
            itemTextPanel.text = hoverObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().flavorText;
            itemSpritePanel.sprite = hoverObject.GetComponent<ItemFace>().myItem.GetComponent<Item>().icon;
            toolTip.SetActive(true);
        }

        //turns off whole tooltip window.
        else
        {
            toolTip.SetActive(false);
        }
    }

    //Looks if the mouse leaves an item card and hits the canvas, then clears the hover object.
    //The reason it is done this way is because the the OnPointerExit on the itemCard isnt accurate when moving the mouse quickly.
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverObject = null;
    }
}
