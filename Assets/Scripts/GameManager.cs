using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //��D�ɃJ�[�h�𐶐�

    [SerializeField] Transform playerHandTransform;
    [SerializeField] CardController cardPrefab;
    void Start()
    {
        CreateCard(playerHandTransform);
    }
    void CreateCard(Transform hand)
    {
        //�J�[�h�̐����ƃf�[�^�̎󂯓n��
        CardController card = Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
        card.Init(1);
    }

    
}
