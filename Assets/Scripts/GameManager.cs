using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]Transform playerHandTransform,
                               enemyHandTransform;
    [SerializeField] CardController cardPrefab;
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        SettingInitHand();
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
    void CreateCard(Transform hand)
    {
        //カードの生成とデータの受け渡し
        CardController card = Instantiate(cardPrefab, hand, false); //カードを生成するときはカードを親として生成する
        card.Init(1);
    }
}
