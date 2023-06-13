using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]Transform playerHandTransform,
                               enemyHandTransform,
                              playerFieldTransform,
                              enemyFieldTransform;
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
            Debug.Log("attacker HP:" + attacker.model.AT);
            Debug.Log("defender HP:" + defender.model.AT);

            attacker.model.Attack(defender);
            defender.model.Attack(attacker);

            Debug.Log("attacker HP:" + attacker.model.AT);
            Debug.Log("defender HP:" + defender.model.AT);
        }
    }
    void CreateCard(Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
        card.Init(1);
    }
}
