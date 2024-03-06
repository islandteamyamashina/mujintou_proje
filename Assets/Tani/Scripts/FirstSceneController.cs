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
            { "����͓��N�O", "�_�X�▂���A�l�Ԃ��푈�����Ă�������", "�\�s�̖����Ƃ��ċ�����Ă�����l�̒j������", "���̖����A�m�X�@���H���f�B�S�[�h" };
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
