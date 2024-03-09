using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory :SingletonMonoBehaviour<Inventory>
{
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);

    }
   
}
