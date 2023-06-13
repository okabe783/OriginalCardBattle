using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードデータとその処理
public class CardModel 
{
    public int AT;
    public Sprite icon;
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity> ("CardEntityList/Card" + cardID);
        AT = cardEntity.AT;
        icon = cardEntity.icon;
    }

      void Damage(int dmg)
    {

    }

    public void Attack(CardController card)
    {
        card.model.Damage(AT);
    }
}
