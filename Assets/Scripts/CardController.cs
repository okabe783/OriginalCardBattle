using UnityEngine;

public class CardController : MonoBehaviour
{
    GameManager gameManager;

    CardView view; //�������Ɋւ��邱�Ƃ𑀍� 
   public CardModel model;//�f�[�^�Ɋւ��邱�Ƃ𑀍�
    public CardMovement movement; //�ړ��Ɋւ��邱�Ƃ𑀍�

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

    public void CheckAlive(CardController defender)  //�X�R�A����
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
