using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; //�������Ɋւ��邱�Ƃ𑀍� 
   public CardModel model;//�f�[�^�Ɋւ��邱�Ƃ𑀍�
    public CardMovement movement; //�ړ��Ɋւ��邱�Ƃ𑀍�

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
