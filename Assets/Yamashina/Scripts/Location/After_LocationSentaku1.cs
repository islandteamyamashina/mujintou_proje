using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class After_LocationSentaku1 : MonoBehaviour
{
    // public GameObject text;
    // public KyotenToOtherspace kyotenToOtherspace;

    [SerializeField] EventTrigger eventTriggerKawabe;
    [SerializeField] EventTrigger eventTrigger_Forest;
    [SerializeField] EventTrigger eventTrigger_Kaigan;
    [SerializeField] EventTrigger eventTrigger_Doukutu;
    [SerializeField] EventTrigger eventTrigger_Sangaku;
    [SerializeField] EventTrigger eventTrigger_Kakou;
    [SerializeField] Button button_Kawabe;
    [SerializeField] Button button_Forest;
    [SerializeField] Button button_Kaigan;
    [SerializeField] Button button_Doukutu;
    [SerializeField] Button button_Sangaku;
    [SerializeField] Button button_Kakou;
    [SerializeField] SceneObject[] nextScene;
    [SerializeField] Button Syupatsu;
    private int num;



    void Start()
    {

        Syupatsu.interactable = false;
        eventTriggerKawabe.enabled = true;
        eventTrigger_Doukutu.enabled = true;
        eventTrigger_Forest.enabled = true;
        eventTrigger_Kaigan.enabled = true;
        eventTrigger_Kakou.enabled = true;
        eventTrigger_Sangaku.enabled = true;
        button_Kawabe.enabled = true;
        button_Forest.enabled = true;
        button_Kaigan.enabled = true;
        button_Kakou.enabled = true;
        button_Doukutu.enabled = true;
        button_Sangaku.enabled = true;


    }
   
   




    public void Sentakuplaces(int num)
    {

        switch (num)
        {
            //�C�ݑI��
            case 0:
                if (button_Kaigan.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    Syupatsu.interactable = true;

                    //num = 0;

                }
                break;
            //�X�I��
            case 1:
                if (button_Forest.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    Syupatsu.interactable = true;

                    //num = 1;
                }
                break;
            //��ӑI��
            case 2:
                if (button_Kawabe.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    num = 2;
                    Syupatsu.interactable = true;

                }
                break;
            //�R�x�I��
            case 3:
                if (button_Sangaku.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    //num = 3;
                    Syupatsu.interactable = true;

                }
                break;
            //�Ό��I��
            case 4:
                if (button_Kakou.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    //num = 4;
                    Syupatsu.interactable = true;

                }
                break;
            //���A�I��
            case 5:
                if (button_Doukutu.onClick != null)
                {
                    Debug.Log(("�V�[�����" + num));
                    //num = 5;
                    Syupatsu.interactable = true;

                }
                break;
        }

    }
    public void LoadScene_each(/*int num_p*/)
    {
        //switch (num_p)
        //{        //�C�ݑI��

            //case 0:
                if (button_Kaigan.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces(0);
                    Debug.Log(("�V�[�����" + num));
                    SceneManager.LoadScene(nextScene[num]);
                }
                //break;
            //�X�I��

            //case 1:
                if (button_Forest.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces(1);

            Debug.Log(("�V�[�����" + num));
                    SceneManager.LoadScene(nextScene[num]);
                }
            //    break;
            ////��ӑI��

            //case 2:
                if (button_Kawabe.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces(2);
            Debug.Log(("�V�[�����" + num));

                    SceneManager.LoadScene(nextScene[num]);
                }
            //    break;

            //case 3:
                if (button_Sangaku.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces(3);
            Debug.Log(("�V�[�����" + num));

                    SceneManager.LoadScene(nextScene[num]);
                }

            //    break;


            //case 4:
                if (button_Kakou.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces (4);
            Debug.Log(("�V�[�����" + num));

                    SceneManager.LoadScene(nextScene[num]);
                }

            //    break;

            //case 5:
                //���A�I��
                if (button_Doukutu.onClick != null && Syupatsu.onClick != null)
                {
            Sentakuplaces(5);
            Debug.Log(("�V�[�����" + num));

                    SceneManager.LoadScene(nextScene[num]);
                }
        //        break;
        //}
    }


    //public void StartSentaku()
    //{
    //    Sentakuplaces(num);

    //}

    //

    public void Cancell()
        {
            num = 6;
            Debug.Log(("�V�[�����" + num));

            SceneManager.LoadScene(nextScene[num]);




        }
    //public void Depature()
    //{
    //    LoadScene_each(num);
    //}


        // �V����UI�p�l����\������֐�

    }
