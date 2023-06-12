using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardMovement : MonoBehaviour, IDragHandler ,IBeginDragHandler,IEndDragHandler　//ID～をクイックアクション→インターフェイスを実装をすると自動でコードを書いてくれる。
{
    public Transform defaultParent;　　//親を決めなければ、離す（OnEndDrag）時に戻ってこない
    public void OnBeginDrag(PointerEventData eventData)    //カードを動かす
    {
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //カードをひっぱった時に行う処理
    {
        transform.position = eventData.position; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
