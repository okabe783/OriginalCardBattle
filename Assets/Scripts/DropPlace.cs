using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
       CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>(); //���Ԃ񂱂��łP�̂��������Ƃ�������������
        if (card != null ) 
        {
            card.defaultParent = this.transform;
        }
    }
}
