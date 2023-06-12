using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    
    [SerializeField] Text numberText;
    [SerializeField] Image iconImage;

    public void Show(CardModel cardModel)
    {
        
        numberText.text = cardModel.number.ToString();
        iconImage.sprite = cardModel.icon;
    }
}

