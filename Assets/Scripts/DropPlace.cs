using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); //‚½‚Ô‚ñ‚±‚±‚Å‚P‘Ì‚¾‚¯‚¾‚·‚Æ‚¢‚¤ˆ—‚ğ‘‚­
        if (card != null ) 
        {
            card.defaultParent = this.transform;
        }
    }
}
