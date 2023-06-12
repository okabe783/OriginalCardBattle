using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J�[�h�f�[�^�Ƃ��̏���
public class CardModel 
{
    public string name;
    public int number;       //int�͐����@string�ŕ����@Tostring�ŕ�����
    public Sprite icon;
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardDataList/Card1");
        name = cardEntity.name;
        number = cardEntity.number;
        icon = cardEntity.icon; 
    }
}
