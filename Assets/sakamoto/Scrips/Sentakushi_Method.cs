
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Sentakushi_Method : Event_Text
{
    [SerializeField] Text _sentakusiTextObject1;
    [SerializeField] Text _sentakusiTextObject2;
    [SerializeField] Text _sentakusiTextObject3;

    //[SerializeField] TextMeshProUGUI _eventTextObject;
    [SerializeField] GameObject _sentakusi1;
    [SerializeField] GameObject _sentakusi2;
    [SerializeField] GameObject _sentakusi3;

    [SerializeField] GameObject shadow1;
    [SerializeField] GameObject shadow2;
    [SerializeField] GameObject shadow3;
    [SerializeField] Fade fade;
    [SerializeField] string scene_Name;

    public Event_Ilast_Disply event_Ilast_Disply;
    public Event_BG_Disply event_BG_Disply;
    public Event_Text event_Text;
    public Event_Manage event_manage;
    public multiAudio multiAudio;
    int[] Result_tam;
    int Result_Num;
    bool SceneContinue;
    bool GoToLoadScene;
    int next_num_tnp;//�ЂƂO�̃C�x���g�i���o�[

    int Event_num;
    // Start is called before the first frame update

    private void Start()
    {
        Event_num = 0;
        Debug.Log(event_manage.start_event_num);
        Set_Sentakusi_Words(event_manage.eventDatas[event_manage.start_event_num].Sentakusi1, 
                            event_manage.eventDatas[event_manage.start_event_num].Sentakusi2, 
                            event_manage.eventDatas[event_manage.start_event_num].Cancel);
        _sentakusiSetActive(event_manage.start_event_num);
        SceneContinue = false;
        GoToLoadScene = false;
    }
    private void Update()
    {
        if (GoToLoadScene)
        {              

            if (Input.GetMouseButton(0))
            {
                GoToEnding();
                //Event_num++;
                //event_Text.SetEventText();
                //event_Ilast_Disply.SetEventIlast();
                //event_BG_Disply.SetEventBG();
                //Set_Sentakusi_Words(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1,
                //                    event_manage.eventDatas[event_manage.now_event_num].Sentakusi2,
                //                    event_manage.eventDatas[event_manage.now_event_num].Cancel);

                //_sentakusiSetActive(event_Manage.now_event_num);
                //_sentakusi1.SetActive(true);
                //_sentakusi2.SetActive(true);
                //_sentakusi3.SetActive(true);
                //GoToLoadScene = false;
                //if(Event_num == 5)
                //{
                //    SceneManager.LoadScene(scene_Name);
                //}    

                //PlayerInfo.Instance.Health
            }
        }
    }
    public void Push_Sentakusi1()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Result1);
            getItem("Sentakusi1");
            //_sentakusi1.SetActive(false);
            _sentakusi2.SetActive(false);
            _sentakusi3.SetActive(false);
            allShadow(false);

            GoToLoadScene = true;

            Debug.Log("�ϊ��O�̗̑͂�" + PlayerInfo.Instance.Health + "�󕠓x��" + PlayerInfo.Instance.Hunger + "������" + PlayerInfo.Instance.Thirst + "�ł�");
            PlayerInfo.Instance.Health += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_health;
            PlayerInfo.Instance.Hunger += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_hunger;
            PlayerInfo.Instance.Thirst += event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_warter;
            Debug.Log("�ϊ���̗̑͂�" + PlayerInfo.Instance.Health + "�󕠓x��" + PlayerInfo.Instance.Hunger + "������" + PlayerInfo.Instance.Thirst + "�ł�");

            next_num_tnp = event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Next_Ivent_ID;
            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }

        }
    }

    public void Push_Sentakusi2()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Result1);
            getItem("Sentakusi2");
            _sentakusi1.SetActive(false);
            _sentakusi3.SetActive(false);
            allShadow(false);

            GoToLoadScene = true;

            Debug.Log("�ϊ��O�̗̑͂�" + PlayerInfo.Instance.Health + "�󕠓x��" + PlayerInfo.Instance.Hunger + "������" + PlayerInfo.Instance.Thirst + "�ł�");
            PlayerInfo.Instance.Health -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_health;
            PlayerInfo.Instance.Hunger -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_hunger;
            PlayerInfo.Instance.Thirst -= event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_warter;
            Debug.Log("�ϊ���̗̑͂�" + PlayerInfo.Instance.Health + "�󕠓x��" + PlayerInfo.Instance.Hunger + "������" + PlayerInfo.Instance.Thirst + "�ł�");

            next_num_tnp = event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Next_Ivent_ID;

            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }

        }
    }

    public void Push_Sentakusi3()
    {
        if (GoToLoadScene == false)
        {
            Text_Disply(event_manage.eventDatas[event_manage.now_event_num].Cancel_Result);
            _sentakusi1.SetActive(false);
            _sentakusi2.SetActive(false);
            allShadow(false);

            GoToLoadScene = true;

            for (int i = 0; i < event_manage.eventDatas.Length; i++)
            {
                if (event_manage.eventDatas[event_manage.now_event_num].Cancel_Next_Ivent_ID == event_manage.eventDatas[i].Event_ID)
                {
                    Debug.Log(event_manage.eventDatas[i].Event_ID);
                    event_manage.now_event_num = i;
                    Debug.Log(event_manage.eventDatas[event_manage.now_event_num].Event_ID);
                    break;
                }
            }
        }
    }

    public void Set_Sentakusi_Words(string Words1, string Words2, string Words3)
    {
        _sentakusiTextObject1.text = Words1;
        _sentakusiTextObject2.text = Words2;
        _sentakusiTextObject3.text = Words3;
    }

    void _sentakusiSetActive(int event_num)
    {
        if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken != 0)
        {
            for (int i = 0; i < event_manage.newItem.Length; i++)
            {
                if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken == event_manage.newItem[i].ScriptalItem.itemID)
                {
                    Debug.Log("�C�x���gID��" + event_manage.newItem[i].ScriptalItem.itemID);
                    Debug.Log("�����̌���" + event_manage.eventDatas[event_num].Sentakusi1_Zyouken_num);
                    Debug.Log("�����Ă������" + event_manage.newItem[i].CurrentStackCount);

                    if (event_manage.eventDatas[event_num].Sentakusi1_Zyouken_num <= event_manage.newItem[i].CurrentStackCount)
                    {

                        shadow1.SetActive(false);
                        break;
                    }
                    else
                    {
                        shadow1.SetActive(true);
                        break;
                    }
                }
            }
        }
        else
        {
            shadow1.SetActive(false);
        }
        if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken != 0)
        {
            for (int i = 0; i < event_manage.newItem.Length; i++)
            {
                if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken == event_manage.newItem[i].ScriptalItem.itemID)
                {
                    if (event_manage.eventDatas[event_num].Sentakusi2_Zyouken_num <= event_manage.newItem[i].CurrentStackCount)
                    {
                        shadow2.SetActive(false);
                    }
                    else
                    {
                        shadow2.SetActive(true);
                    }
                }
            }
        }
        else
        {
            shadow2.SetActive(false);
        }
        shadow3.SetActive(false);
    }
    void getItem(string Sentakusi)
    {
        if (Sentakusi == "Sentakusi1")
        {
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward1_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward2_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi1_Reward3_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            
        }
        if (Sentakusi == "Sentakusi2")
        {
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward1 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward1 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward1_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward2_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
            if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3 != 0)
            {
                for (int i = 0; i < event_manage.newItem.Length; i++)
                {
                    if (event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3 == event_manage.newItem[i].ScriptalItem.itemID)
                    {
                        Debug.Log(event_manage.newItem[i].ScriptalItem.name + "���Q�b�g���܂���");
                        for (int j = 0; j < event_manage.eventDatas[event_manage.now_event_num].Sentakusi2_Reward3_num; j++)
                        {
                            Debug.Log("get");
                        }
                    }
                }
            }
        }

    }

    void GoToEnding()
    {
        Debug.Log(next_num_tnp);
        Debug.Log(next_num_tnp / 1000);
        //�g�D���[�G���h
        if(next_num_tnp / 1000 == 0)
        {
            fade.feadout_f = true;
            multiAudio.SE1();
            Debug.Log("�g�D���[�G���h");
            //SceneManager.LoadScene("TrueEnd");
        }
        //�o�b�h�G���h
        else if(PlayerInfo.Instance.Health == 0)
        {
            fade.scene_name = "BadEnd";
           fade.feadout_f = true;
            multiAudio.SE1();
            Debug.Log("�o�b�h�G���h");
            //SceneManager.LoadScene("BadEnd");
        }
        else
        {
            Event_num++;
            event_Text.SetEventText();
            event_Ilast_Disply.SetEventIlast();
            event_BG_Disply.SetEventBG();
            Set_Sentakusi_Words(event_manage.eventDatas[event_manage.now_event_num].Sentakusi1,
                                event_manage.eventDatas[event_manage.now_event_num].Sentakusi2,
                                event_manage.eventDatas[event_manage.now_event_num].Cancel);

            _sentakusiSetActive(event_Manage.now_event_num);
            _sentakusi1.SetActive(true);
            _sentakusi2.SetActive(true);
            _sentakusi3.SetActive(true);
            GoToLoadScene = false;
            if (Event_num == 5)
            {
                SceneManager.LoadScene(scene_Name);
            }

            //PlayerInfo.Instance.Health

        }
    }
    protected
       void allShadow(bool check)
       {
           shadow1.SetActive(check);
           shadow2.SetActive(check);
           shadow3.SetActive(check);
       }
}

//�S�ẴV���h�E�̃Z�b�g�A�N�e�B�u���I���E�I�t����
