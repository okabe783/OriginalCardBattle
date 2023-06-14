using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�J�[�h�f�[�^�Ƃ��̏���
public class CardModel 
{
    public int at;
    public int cost;
    public int hp;
    public Sprite icon;
    public  bool useCard;  //�g�p�������ǂ�����������ς���

    
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity> ("CardEntityList/Card" + cardID);
        at = cardEntity.AT;
        hp = cardEntity.Hp;
        cost = cardEntity.Cost;
        icon = cardEntity.icon;
        useCard = true;
    }

      void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            useCard = false;�@�@//��킹����g�p�ς݂ɂ���
        }
    }

    public void Attack(CardController card)
    {
        card.model.Damage(at);
    }
}
