using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; //Œ©‚©‚¯‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì 
    
    CardModel model;//ƒf[ƒ^‚ÉŠÖ‚·‚é‚±‚Æ‚ğ‘€ì

    private void Awake()
    {
        view = GetComponent<CardView>();
    }
    public void Init(int cardID)
    {
        model = new CardModel(cardID);
        view.Show(model);
    }
}
