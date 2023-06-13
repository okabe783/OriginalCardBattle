using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardView : MonoBehaviour
{
    [SerializeField] Text  ATText;
    [SerializeField] Text  HpText;
    [SerializeField] Text  CostText;
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel)
    {
        HpText.text = cardModel.hp.ToString();
        ATText.text = cardModel.at.ToString();
        CostText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;
    }
}
