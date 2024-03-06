using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    int page = 0;
    string[] strings ;
    [SerializeField]
    TextControl textControl;

    void Start()
    {
        strings = new string[]
            { "これは二千年前", "神々や魔族、人間が戦争をしていた時代", "暴虐の魔王として恐れられていた一人の男がいた", "その名もアノス　ヴォルディゴード" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {
        page++;
        textControl.ResetTextData();
        textControl.AddTextData(strings[page]);
    }

}
