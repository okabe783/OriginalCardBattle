using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J�[�h�f�[�^�Ƃ��̏���
public class CardModel 
{
    public int AT;
    public int Cost;
    public Sprite icon;
    
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity> ("CardEntityList/Card" + cardID);
        AT = cardEntity.AT;
        Cost = cardEntity.Cost;
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
