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
        //�J�[�h�����ꂼ���5���z��
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
        Debug.Log("���̃^�[��");
    }
    void EnemySetting()
    {
        Debug.Log("����̃^�[��");
        SettingTurn();
    }
    void CreateCard(Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
        card.Init(1);
    }
}
