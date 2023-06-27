using UnityEngine;

//カードデータとその処理
public class CardModel 
{
    public int at;
    public int cost;
    public int hp;
    public Sprite icon;
    public  bool isAlive;
    public bool isFieldCard;
    public bool isEnemyCard;
    
    public CardModel(int cardID,bool isEnemyCard)
    {
        CardEntity cardEntity = Resources.Load<CardEntity> ("CardEntityList/Card" + cardID);
        at = cardEntity.AT;
        hp = cardEntity.Hp;
        cost = cardEntity.Cost;
        icon = cardEntity.icon;
        isAlive = true;
        this.isEnemyCard = isEnemyCard;
        
    }

      void Damage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            isAlive = false;
        }
    }

    public void Attack(CardController card)
    {
        card.model.Damage(at);
    }
}
