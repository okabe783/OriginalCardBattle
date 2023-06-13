using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; //Œ©‚©‚¯‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì 
   public CardModel model;//ƒf[ƒ^‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì
    public CardMovement movement; //ˆÚ“®‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì

    private void Awake()
    {
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
    }
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}
