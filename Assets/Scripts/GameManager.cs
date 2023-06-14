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

    public static float score;
    public static float score_before;
    bool isPlayerSetting;

    //�f�b�L�̍쐬
    List<int> playerDeck = new List<int>(){1,2,3,4,5},
              enemyDeck = new List<int>() {1,2,3,4,5};

    

    void Start()
    {
        //Playerscore_text = GameObject.Find("Score");
        StartGame();

        score = 0;
    }

    public void Update()
    {
        Text playerscore_text = Playerscore_text.GetComponent<Text>();
        playerscore_text.text = score.ToString();

    }
    void StartGame()
    {
        SettingInitHand();
        isPlayerSetting = true;
        TurnCalc();
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
    void EnemySetting()
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
            attacker.CheckAlive();
            defender.CheckAlive();
        }  
    }
   public  void ScoreUp()
    {
        score ++;
    }
   //      public void ScoreCard(CardController attacker, bool isPlayerCard)  //�����J�[�h���ׂď������Ȃ�΃X�R�A���{�P����
     //  {
      //   if (isPlayerCard)
       //{
        //    score_before = score;
       // }
    //  else
    // {

    //            }
    //   }
}
