using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemFace : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    //This script is on every itemCard prefab. An itemCard is a UI element that can be dragged, and informs the tooltip window if the card that is selected.

    public Inventory inventory;
    public Transform parentToReturnTo;
    public bool dragMe;
    public bool hoverMe;
    public Item myItem;
    public Image cardIcon;

    void Start()
    {
        cardIcon.sprite = myItem.GetComponent<Item>().icon;
        inventory = GameObject.Find("Canvas").GetComponent<Inventory>();

        //Gives card a lonely parent to live with.
        //Card moves in with parent.
        this.transform.position = inventory.spawnParent.transform.position;
        this.transform.SetParent(inventory.spawnParent.transform);

        //Goes through itemshells list to look for a lonely parent.
        for (int i = 0; i < inventory.shells.Count; i++)
        {
            if (inventory.shells[i].transform.childCount == 0)
            {
                inventory.spawnParent = inventory.shells[i];
                i = inventory.shells.Count;
            }
        }
    }
  
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Moves the card up the parent tree once when being dragged.
        //Also disables raycast target on this card so the mouse can look underneath it.
        //Puts this card in a public Gameobject in Inventory.cs so everyone can look at it.
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);      
        GetComponent<Image>().raycastTarget = false;
        inventory.heldObject = this.gameObject;
        dragMe = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Makes the card follow the mouse when dragging.
        this.gameObject.transform.position = eventData.position;                 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //User lets go of mouse1.
        //Card returns to its correct parent.
        //Clears heldItem in Inventory.cs.
        this.transform.SetParent(parentToReturnTo);       
        inventory.heldObject = null;
        GetComponent<Image>().raycastTarget = true;
        this.transform.position = parentToReturnTo.position;
        dragMe = false;

        //Calculates new spot.
        for (int i = 0; i < inventory.shells.Count; i++)
        {
            if (inventory.shells[i].transform.childCount == 0)
            {
                inventory.spawnParent = inventory.shells[i];
                i = inventory.shells.Count;
            }
        }
    }

    //Looks at hovering
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverMe = true;
        inventory.hoverObject = this.gameObject;
    }
}
