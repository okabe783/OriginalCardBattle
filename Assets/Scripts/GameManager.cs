using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //手札にカードを生成

    [SerializeField] Transform playerHandTransform;
    [SerializeField] CardController cardPrefab;
    void Start()
    {
        CreateCard(playerHandTransform);
    }
    void CreateCard(Transform hand)
    {
        //カードの生成とデータの受け渡し
        CardController card = Instantiate(cardPrefab, hand, false); //カードを生成するときはカードを親として生成する
        card.Init(1);
    }

    
}
