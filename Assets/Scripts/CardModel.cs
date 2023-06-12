using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードデータとその処理
public class CardModel 
{
    public string name;
    public int number;       //intは数字　stringで文字　Tostringで文字列
    public Sprite icon;
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardDataList/Card1");
        name = cardEntity.name;
        number = cardEntity.number;
        icon = cardEntity.icon; 
    }
}
