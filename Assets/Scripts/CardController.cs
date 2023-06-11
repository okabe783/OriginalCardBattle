using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    CardModel model;

    public void OnServerInitialized()
    {
        model = new CardModel();
    }
}
