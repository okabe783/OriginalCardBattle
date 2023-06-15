using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    List<int> playerDeck = new List<int>(){1,2,3,4,5},
              enemyDeck = new List<int>() {1,2,3,4,5};

    [SerializeField] Text playerHeroHpText,
                          enemyHeroHpText;

    int playerHeroHp;
    int enemyHeroHp;
    

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
        SettingInitHand();
        isPlayerSetting = true;
        TurnCalc();
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
        playerDeck = new List<int>() { 1, 2, 3, 4, 5 };
                   enemyDeck = new List<int>() { 1, 2, 3, 4, 5 };
        StartGame();
    }

    void SettingInitHand()
    {
        //�J�[�h�����ꂼ���5���z��
        for (int i = 0; i < 5; i++)
        {
            GiveCardToHand(playerDeck,playerHandTransform);
            GiveCardToHand(enemyDeck,enemyHandTransform);
        }
    }
    void GiveCardToHand(List<int> deck, Transform hand)
    {
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID,hand);
    }
    void CreateCard(int cardID,Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
        card.Init(cardID);
    }

    private void TurnCalc()
    {
        if (isPlayerSetting)
        {
            PlayerSetting();
        }
        else
        {
            EnemySetting();
        }
    }

    public void SettingTurn()
    {
        isPlayerSetting = !isPlayerSetting;
        TurnCalc();
    }

    void PlayerSetting()
    {
        Debug.Log("���̃^�[��");
    }
    void EnemySetting()�@�@//���肪�J�[�h���o�����^�C�~���O�Ńo�g��������
    {
        Debug.Log("����̃^�[��");
        /*��ɃJ�[�h������*/
        //��D�̃J�[�h���X�g���擾
        CardController[]handcardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        //��ɏo���J�[�h��I��
        CardController enemycard = handcardList[0];
        //�J�[�h���ړ�
        enemycard.movement.SetCardTransform(enemyFieldTransform);
        /* �U����r */
        //�t�B�[���h�̃J�[�h���X�g���擾
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        //attacker�J�[�h��I��
        CardController attacker = fieldCardList[0];
        //defender�J�[�h��I��
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        CardController defender = playerFieldCardList[0];
        //attacker��defender���킹��
        CardsBattle(attacker,defender);
        

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
       
        if (playerscore >= 3)
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
