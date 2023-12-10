using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Title_Manager : SingletonMonoBehaviour<S_Title_Manager>
{
    public int a = 1;
    public int b = 3;
    private int c = 5;
    public int GetC() { return c; }
    


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        a++;
    }
}

