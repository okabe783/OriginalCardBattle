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
        //�J�[�h�����ꂼ���5���z��
        for (int i = 0; i < 5; i++)
        {
            CreateCard(playerHandTransform);
            CreateCard(enemyHandTransform);
        }
    }
    void CreateCard(Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
        card.Init(1);
    }
}
