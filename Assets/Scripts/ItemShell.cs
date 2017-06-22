using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemShell : MonoBehaviour, IPointerEnterHandler
{
    //This script is on all itemShells. ItemShells are the gridboxes that make up the inventory.
    public Inventory inventory;

    //Looks at the shell you are pointing at, checks if it has no children, checks if you are holding a card, then adopts the card.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            if (inventory.heldObject != null)
            {
                print(inventory.heldObject + "has been adopted by" + this.gameObject.name);
                inventory.heldObject.GetComponent<ItemFace>().parentToReturnTo = this.gameObject.transform;
            }
        }
    }    
}
