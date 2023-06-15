using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CardController : MonoBehaviour
{
    GameManager gameManager;

    CardView view; //�������Ɋւ��邱�Ƃ𑀍� 
   public CardModel model;//�f�[�^�Ɋւ��邱�Ƃ𑀍�
    public CardMovement movement; //�ړ��Ɋւ��邱�Ƃ𑀍�

    private void Awake()
    {
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
        gameManager = FindObjectOfType<GameManager>();

    }
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
    public void CheckAlive(CardController defender)  //�X�R�A����
    {
        if (model.isAlive == false)
        {
            
            gameManager.PlayerScoreUp();
        }
        else
        {
            gameManager.EnemyScoreUp();
        }
        Destroy(this.gameObject);
        Destroy(defender.gameObject);  
    }
}
