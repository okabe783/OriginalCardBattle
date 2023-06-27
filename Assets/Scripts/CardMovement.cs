using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardMovement : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
   public Transform defaultParent;

   public  bool isDraggable;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�J�[�h�̃R�X�g��Player��Mana�R�X�g���r
        CardController card = GetComponent<CardController>();
        if (!card.model.isFieldCard && card.model.cost <= GameManager.instance.playerManaCost)
        {
            isDraggable = true;
        }
        
        else
        {
            isDraggable = false;
        }
        if (!isDraggable)
        {
            return;
        }

        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent,false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable)
        {
            return;
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable)
        {
            return;
        }
        transform.SetParent(defaultParent,false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public  IEnumerator MoveToField(Transform field)
    {
        //��x�e��Canvas�ɕύX����
        transform.SetParent(defaultParent.parent);
        //DOTWEEN�ŃJ�[�h���t�B�[���h�Ɉړ�
        transform.DOMove(field.position,0.25f);
        yield return new WaitForSeconds(0.25f);
        defaultParent = field;
        transform.SetParent(defaultParent);
    }
    public IEnumerator MoveToTarget(Transform target)
    {
        Vector3 currenPosition = transform.position;
        //��x�e��Canvas�ɕύX����
        transform.SetParent(defaultParent.parent);
        //DOTWEEN�ŃJ�[�h��Target�Ɉړ�
        transform.DOMove(target.position, 0.25f);
        yield return new WaitForSeconds(0.25f);
    }

    void Start()
    {
        defaultParent = transform.parent;
    }
}
