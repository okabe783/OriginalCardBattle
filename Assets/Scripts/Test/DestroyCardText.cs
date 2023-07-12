using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCardText : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
