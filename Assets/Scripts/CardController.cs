using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CardController : MonoBehaviour
{
    GameManager gameManager;

    CardView view; //Œ©‚©‚¯‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì 
   public CardModel model;//ƒf[ƒ^‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    public CardMovement movement; //ˆÚ“®‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì

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
    public void CheckAlive()
    {
        if (model.useCard)
        {
            gameManager.PlayerScoreUp();
        }
        else
        {
            gameManager.EnemyScoreUp();
        }
            Destroy(this.gameObject);
    }
}
