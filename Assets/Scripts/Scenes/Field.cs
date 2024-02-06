using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Field : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Init();
    }
    
    
    
}
