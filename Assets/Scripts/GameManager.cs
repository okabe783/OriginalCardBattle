using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //��D�ɃJ�[�h�𐶐�

    [SerializeField] Transform playerHandTransform;
    [SerializeField] GameObject cardPrefab;
    private void Start()
    {
        CreateCard(playerHandTransform);
    }
    void CreateCard(Transform hand)
    {
        Instantiate(cardPrefab, hand, false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
    }

    
}
