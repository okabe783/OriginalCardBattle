using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; //見かけに関することを操作 
   public CardModel model;//データに関することを操作
    public CardMovement movement; //移動に関することを操作

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
