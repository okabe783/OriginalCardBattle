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
        Instantiate(cardPrefab, playerHandTransform,false); //�J�[�h�𐶐�����Ƃ��̓J�[�h��e�Ƃ��Đ�������
    }
}
