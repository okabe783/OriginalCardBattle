using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardMovement : MonoBehaviour, IDragHandler ,IBeginDragHandler,IEndDragHandler�@//ID�`���N�C�b�N�A�N�V�������C���^�[�t�F�C�X������������Ǝ����ŃR�[�h�������Ă����B
{
    public Transform defaultParent;�@�@//�e�����߂Ȃ���΁A�����iOnEndDrag�j���ɖ߂��Ă��Ȃ�
    public void OnBeginDrag(PointerEventData eventData)    //�J�[�h�𓮂���
    {
        defaultParent = transform.parent;
        transform.SetParent(defaultParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //�J�[�h���Ђ��ς������ɍs������
    {
        transform.position = eventData.position; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
