using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class After_LocationSentaku1 : MonoBehaviour
{
    public GameObject newPanel; // �V����UI�p�l���ւ̎Q��
                                // public GameObject text;

    [SerializeField]
    string sceneName;


    void Start()
    {
        newPanel.SetActive(false); // �p�l����\������

    }
    public void OnClick()
    {
        // �}�E�X�̍��N���b�N�����m

        ShowNewPanel(); // �V����UI�p�l��(After_locationsentaku�p�l����\��
                        //  text.SetActive(true);

    }



    public void yesnobutton(int num) //�����Ɉ��������Ă������Ƃł��ꂼ��̃{�^�����Ƃ�Unity���ň������w��ł���B
    {

        switch (num)
        {


            case 1: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                Debug.Log("A�̃{�^���������ꂽ��");
                SceneManager.LoadScene(sceneName);

                break;
            case 2: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������2�̂������Ƃ�
                Debug.Log("B�̃{�^���������ꂽ��");
                newPanel.SetActive(false);
                break;

        }

    }


    // �V����UI�p�l����\������֐�
    public void ShowNewPanel()
    {
        newPanel.SetActive(true); // �p�l����\������

    }
}
