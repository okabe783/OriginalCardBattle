using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerHandTransform,
                               enemyHandTransform,
                               playerFieldTransform,
                               enemyFieldTransform;
    [SerializeField] CardController cardPrefab;
    [SerializeField] GameObject Playerscore_text;
    [SerializeField] GameObject Enemyscore_text;
    [SerializeField] GameObject resultPanel;
    [SerializeField] Text resultText;

    public static float playerscore;
    public static float enemyscore;
    public static float score_before;
    bool isPlayerSetting;

    //�f�b�L�̍쐬
    List<int> playerDeck = new List<int>(){1,2,3,4,5,6,7,8},
              enemyDeck = new List<int>() {1,2,3,4,5,6,7,8};

    [SerializeField] Text playerHeroHpText,
                          enemyHeroHpText;

    [SerializeField] Text playerManaCostText;
    [SerializeField] Text enemyManaCostText;

    public  int playerManaCost;
    public  int enemyManaCost;
    public int playerDefaultManaCost;
    public int enemyDefaultManaCost;
    public static GameManager instance;
    public bool isEnemyCardGenerateTurn = false;
    bool _isPuttingCard;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        StartGame();
        playerscore = 0;
        enemyscore = 0;
    }

    public void Update()�@�@//�X�R�A
    {
        Text playerscore_text = Playerscore_text.GetComponent<Text>();
        playerscore_text.text = playerscore.ToString();
        Text enemyscore_text = Enemyscore_text.GetComponent<Text>();
        enemyscore_text.text = enemyscore.ToString();
    }
    void StartGame()
    {
        resultPanel.SetActive(false);
        playerManaCost = 1;
        enemyManaCost = 1;
        playerDefaultManaCost = 1;
        enemyDefaultManaCost = 1;
        ShowManaCost();
        SettingInitHand();
      


        isPlayerSetting = true;
      
        TurnCalc();
    }

    public  void ShowManaCost()
    {
        playerManaCostText.text = playerManaCost.ToString();
        enemyManaCostText.text = enemyManaCost.ToString();

    }
    public void ReduceManaCost(int cost, bool isPlayerCard)
    {
        if (isPlayerCard)
        {
            playerManaCost -= cost;
        }
        else
        {
            enemyManaCost -= cost;
        }
        ShowManaCost();
    }


    public void ReStart() //�^�C�g������ăX�^�[�g�����鏈��
    {
        //hand��Field�̃J�[�h���폜
        foreach(Transform card in playerHandTransform)
        {
               Destroy(card.gameObject);
        }
        foreach (Transform card in playerFieldTransform)
        {
            Destroy(card.gameObject);
        }
        foreach (Transform card in enemyHandTransform)
        {
            Destroy(card.gameObject);
        }
        foreach (Transform card in enemyFieldTransform)
        {
            Destroy(card.gameObject);
        }


        //�f�b�L�𐶐�
        playerDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8};
         enemyDeck = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8};

        if (playerscore == 3)
        {
            playerscore = 0;
        }
        else
        {
            enemyscore = 0;
        }
       

        StartGame();
    }
    void SettingInitHand()
    {
        //�J�[�h�����ꂼ���8���z��
        for (int i = 0; i < 8; i++)
        {
            GiveCardToHand(playerDeck,playerHandTransform);
            isEnemyCardGenerateTurn=true;

            Shuffle();
            GiveCardToHand(enemyDeck,enemyHandTransform);
            isEnemyCardGenerateTurn = false;
            //Debug.Log(enemyDeck.Count);
        }
    }
    void GiveCardToHand(List<int> deck, Transform hand)
    {
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID, hand) ;      
    }
    void CreateCard(int cardID,Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������

        if(isEnemyCardGenerateTurn == true)
        {
            card.gameObject.GetComponent<CardView>().PanelActive(true);
        }
        card.Init(cardID,isEnemyCardGenerateTurn);
    }

    void Shuffle()
    {
        //����n�̏����l�̓f�b�L����
        int n = enemyDeck.Count;

        //n��1��菬�����Ȃ�܂ŌJ��Ԃ�
        while(n > 0)
        {
            n--;

            //k��0�`n+1�̊Ԃ̃����_���Ȓl
            int k =UnityEngine.Random.Range(0, n + 1);

            //k�Ԗڂ̃J�[�h��temp�ɑ��
            int temp = enemyDeck[k];
            enemyDeck[k] = enemyDeck[n];
            enemyDeck[n] = temp;
        }
    }

    private void TurnCalc()
    {
        if (isPlayerSetting)
        {
            PlayerSetting();
          
        }
        else
        {
          StartCoroutine(EnemySetting());
           
        }
    }

    public void SettingTurn()
    {
        isPlayerSetting = !isPlayerSetting;
        if (isPlayerSetting)
        playerManaCost = playerDefaultManaCost;
        else
        {
            enemyManaCost = enemyDefaultManaCost;
        }
        
        TurnCalc();
    }

    void PlayerSetting()
    {
        Debug.Log("���̃^�[��");
    }
    IEnumerator EnemySetting()�@�@//���肪�J�[�h���o�����^�C�~���O�Ńo�g��������
    {
        //defender�J�[�h��I��
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        if (playerFieldCardList.Length == 0) yield break;
        CardController defender = playerFieldCardList[0];
        Debug.Log("����̃^�[��");

        /*��ɃJ�[�h������*/
        //��D�̃J�[�h���X�g���擾
        CardController[]handcardList = enemyHandTransform.GetComponentsInChildren<CardController>();

        //��ɏo���J�[�h��I��
        int rnd = Random.Range(1, 2);
        CardController enemycard = handcardList[rnd];
        enemycard.gameObject.GetComponent<CardView>().PanelActive(false);
        //�J�[�h���ړ�
        StartCoroutine(enemycard.movement.MoveToField(enemyFieldTransform));

        yield return new WaitForSeconds(1);

        /* �U����r */
        
        //�t�B�[���h�̃J�[�h���X�g���擾
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        //attacker�J�[�h��I��
        CardController attacker = fieldCardList[0];
        //attacker��defender���킹��
        StartCoroutine(attacker.movement.MoveToTarget(defender.transform));

        CardsBattle(attacker,defender);

        yield return new WaitForSeconds(1);
        SettingTurn();

        void CardsBattle(CardController attacker, CardController defender)
        {
            Debug.Log("CardBattle");
            Debug.Log("attacker HP:" + attacker.model.hp);
            Debug.Log("defender HP:" + defender.model.hp);

            attacker.model.Attack(defender);
            defender.model.Attack(attacker);

            Debug.Log("attacker HP:" + attacker.model.hp);
            Debug.Log("defender HP:" + defender.model.hp);
            attacker.CheckAlive(defender);
            CheckScore();
            //defender.CheckAlive();
        }  
    }
   public  void PlayerScoreUp()
    {
        playerscore ++;
    }
    public void EnemyScoreUp()
    {
        enemyscore ++;
    }
   
    void CheckScore()   //���U���g��ʂ̕\��
    {
       
        if (playerscore >= 4)
        {
            resultText.text = "WIN";
            resultPanel.SetActive(true);
        }
        else if (enemyscore >= 3) 
        {
            resultText.text = "LOSE";
            resultPanel.SetActive(true);
        }
    }
}
