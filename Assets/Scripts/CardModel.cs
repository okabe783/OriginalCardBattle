using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel 
{
    public string cardname;
    public int number;       //int�͐����@string�ŕ����@Tostring�ŕ�����
    public Sprite icon;
    public CardModel()
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardData/DragonCard");
    }
}
