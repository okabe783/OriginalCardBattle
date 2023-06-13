using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardView : MonoBehaviour
{
    [SerializeField] Text  ATText;
    [SerializeField] Text  CostText;
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel)
    {
        ATText.text = cardModel.AT.ToString();
        ATText.text = cardModel.Cost.ToString();
        iconImage.sprite = cardModel.icon;
    }
}
