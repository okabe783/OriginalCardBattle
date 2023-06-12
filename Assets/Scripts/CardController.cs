using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardView view; //�������Ɋւ��邱�Ƃ𑀍�
    CardModel model;�@//�f�[�^�Ɋւ��邱�Ƃ𑀍�

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
