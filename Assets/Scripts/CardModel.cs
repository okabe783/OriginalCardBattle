using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel 
{
    public string cardname;
    public int number;       //intは数字　stringで文字　Tostringで文字列
    public Sprite icon;
    public CardModel()
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardData/DragonCard");
    }
}
