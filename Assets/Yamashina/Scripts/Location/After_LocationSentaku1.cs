using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class After_LocationSentaku1 : MonoBehaviour
{
    public GameObject newPanel; // �V����UI�p�l���ւ̎Q��
                                // public GameObject text;
                                // public KyotenToOtherspace kyotenToOtherspace;
    
    [SerializeField] Fade fade;
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




    void Start()
    {
        newPanel.SetActive(false); // �p�l����\������
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
        button_Sangaku.enabled =true;   


    }
    public void OnClick()
    {
        // �}�E�X�̍��N���b�N�����m

        ShowNewPanel(); // �V����UI�p�l��(After_locationsentaku�p�l����\��
                        //  text.SetActive(true);
        eventTriggerKawabe.enabled =false;
        eventTrigger_Doukutu.enabled = false;
        eventTrigger_Forest.enabled = false;
        eventTrigger_Kaigan.enabled = false;
        eventTrigger_Kakou.enabled = false;
        eventTrigger_Sangaku.enabled = false;
        //�{�^���֘A
        button_Kawabe.enabled = false;
        button_Forest.enabled = false;
        button_Kaigan.enabled = false;
        button_Kakou.enabled = false;
        button_Doukutu.enabled = false;
        button_Sangaku.enabled = false;
    }



    public void yesnobutton(int num) //�����Ɉ��������Ă������Ƃł��ꂼ��̃{�^�����Ƃ�Unity���ň������w��ł���B
    {

        switch (num)
        {


            case 1: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������1�̂������Ƃ�
                Debug.Log("A�̃{�^���������ꂽ��");
                fade.feadout_f = true;
                fade.scene_name_num = num;

                break;
            case 2: //�����ꂽ�{�^����Unity���Őݒ肳�ꂽ������2�̂������Ƃ�
                Debug.Log("B�̃{�^���������ꂽ��");
                newPanel.SetActive(false);
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
                //  kyotenToOtherspace.MainView();

                break;

        }

    }


    // �V����UI�p�l����\������֐�
    public void ShowNewPanel()
    {
        newPanel.SetActive(true); // �p�l����\������
       

    }
}
