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
        Instantiate(cardPrefab, playerHandTransform,false); //カードを生成するときはカードを親として生成する
    }
}
