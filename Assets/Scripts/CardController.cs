using UnityEngine;

public class CardController : MonoBehaviour
{
    GameManager gameManager;

    CardView view; //見かけに関することを操作 
   public CardModel model;//データに関することを操作
    public CardMovement movement; //移動に関することを操作

    private void Awake()
    {
        view = GetComponent<CardView>();
        movement = GetComponent<CardMovement>();
        gameManager = FindObjectOfType<GameManager>();

    }
    public void Init(int cardID,bool isEnemyTurn)
    {
        model = new CardModel(cardID,isEnemyTurn);
        view.SetCard(model);
    }

    public void CheckAlive(CardController defender)  //スコア判定
    {
        if (model.isAlive == false)
        {
            
            gameManager.PlayerScoreUp();
        }
        else
        {
            gameManager.EnemyScoreUp();
        }
        Destroy(this.gameObject);
        Destroy(defender.gameObject);  
    }
}
