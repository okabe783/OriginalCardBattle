using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CardController : MonoBehaviour
{
    GameManager gameManager;

    CardView view; //見かけに関することを操作 
   public CardModel model;//データに関することを操作
    public CardMovement movement; //移動に関することを操作

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
    public void CheckAlive(CardController defender)  //スコア判定
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
