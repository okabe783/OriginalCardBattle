using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); //たぶんここで１体だけだすという処理を書く
        if (card != null ) 
        {
            card.defaultParent = this.transform;
        }
    }
}
