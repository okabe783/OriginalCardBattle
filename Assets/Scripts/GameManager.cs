using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //手札にカードを生成

    [SerializeField] Transform playerHandTransform;
    [SerializeField] GameObject cardPrefab;
    private void Start()
    {
        CreateCard(playerHandTransform);
    }
    void CreateCard(Transform hand)
    {
        Instantiate(cardPrefab, hand, false); //カードを生成するときはカードを親として生成する
    }

    
}
