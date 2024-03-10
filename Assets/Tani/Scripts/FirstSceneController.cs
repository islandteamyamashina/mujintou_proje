using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    int page = -1;
    string[] strings ;

    [SerializeField]
    TextControl textControl;

    bool isFirst = true;

    void Start()
    {
        strings = new string[]
            { "muzinntou", "無人島無人島無人島無人島無人島", "aaaaaaaaaaaaaaaaaaaaaaaa", "ありがとうございました。" };
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isFirst)
        //{
        //    textControl.AddTextData("hell0");
        //    isFirst = false;
        //}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextPage();
        }


      

    }

    public void NextPage()
    {
        page++;
        textControl.ResetTextData();
        textControl.AddTextData(strings[page]);
    }

    public void Onhover()
    {
        PlayerInfo.Instance.SetMouseCursor(0);
    }
}
