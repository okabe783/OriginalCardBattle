using UnityEngine;
using UnityEngine.UI;


public class CardView : MonoBehaviour
{
    [SerializeField] Text  ATText;
    [SerializeField] Text  HpText;
    [SerializeField] Text  CostText;
    [SerializeField] Image iconImage;
    [SerializeField] GameObject maskPanel;

    public void SetCard(CardModel cardModel)
    {
        HpText.text = cardModel.hp.ToString();
        ATText.text = cardModel.at.ToString();
        CostText.text = cardModel.cost.ToString();
        iconImage.sprite = cardModel.icon;     
        maskPanel.SetActive(cardModel.isEnemyCard);
    }

    public void PanelActive(bool isActive)
    {
        maskPanel.SetActive(isActive);
    }

}
