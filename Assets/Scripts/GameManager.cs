using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]Transform playerHandTransform,
                               enemyHandTransform;
    [SerializeField] CardController cardPrefab;

    bool isPlayerSetting;
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
            CreateCard(playerHandTransform);
            CreateCard(enemyHandTransform);
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
        SettingTurn();
    }
    void CreateCard(Transform hand)
    {
        //カードの生成とデータの受け渡し
        CardController card = Instantiate(cardPrefab, hand, false); //カードを生成するときはカードを親として生成する
        card.Init(1);
    }
}
