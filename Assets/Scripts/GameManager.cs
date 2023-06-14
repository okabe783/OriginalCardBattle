using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerHandTransform,
                               enemyHandTransform,
                              playerFieldTransform,
                              enemyFieldTransform;
    [SerializeField] CardController cardPrefab;

    bool isPlayerSetting;

    List<int> playerDeck = new List<int>(){1,2,3,4,5},
              enemyDeck = new List<int>() {1,2,3,4,5};

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        SettingInitHand();
        isPlayerSetting = true;
        TurnCalc();
    }

    void SettingInitHand()
    {
        //カードをそれぞれに5枚配る
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
        //カードの生成とデータの受け渡し
        CardController card = Instantiate(cardPrefab, hand, false); //カードを生成するときはカードを親として生成する
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
        Debug.Log("俺のターン");
    }
    void EnemySetting()
    {
        Debug.Log("相手のターン");
        /*場にカードをだす*/
        //手札のカードリストを取得
        CardController[]handcardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        //場に出すカードを選択
        CardController enemycard = handcardList[0];
        //カードを移動
        enemycard.movement.SetCardTransform(enemyFieldTransform);
        /* 攻撃比較 */
        //フィールドのカードリストを取得
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        //attackerカードを選択
        CardController attacker = fieldCardList[0];
        //defenderカードを選択
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        CardController defender = playerFieldCardList[0];
        //attackerとdefenderを戦わせる
        CardsBattle(attacker,defender);
        

        SettingTurn();

        void CardsBattle(CardController attacker, CardController defender)
        {
            Debug.Log("CardBattle");
            Debug.Log("attacker AT:" + attacker.model.at);
            Debug.Log("defender AT:" + defender.model.at);

            attacker.model.Attack(defender);
            defender.model.Attack(attacker);

            Debug.Log("attacker AT:" + attacker.model.at);
            Debug.Log("defender AT:" + defender.model.at);
            attacker.CheckAlive();
            defender.CheckAlive();
        }
        
        
    }
   
}
