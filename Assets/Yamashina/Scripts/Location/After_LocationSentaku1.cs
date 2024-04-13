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

    [SerializeField] EventTrigger eventTrigger_Kawabe;
    [SerializeField] EventTrigger eventTrigger_Forest;
    [SerializeField] EventTrigger eventTrigger_Kaigan;
    [SerializeField] EventTrigger eventTrigger_Doukutu;
    [SerializeField] EventTrigger eventTrigger_Sangaku;
    [SerializeField] EventTrigger eventTrigger_Kakou;
    [SerializeField] GameObject Panel;
    [SerializeField] Button button_Kawabe;
    [SerializeField] Button button_Forest;
    [SerializeField] Button button_Kaigan;
    [SerializeField] Button button_Doukutu;
    [SerializeField] Button button_Sangaku;
    [SerializeField] Button button_Kakou;
    [SerializeField] SceneObject[] nextScene;
    [SerializeField] Image_change image_Change;
    [SerializeField] Button Syupatsu;
    private int num;
    private int Choice_num;


    void Start()
    {

        eventTrigger_Forest.enabled = true;
        Syupatsu.interactable = false;
        eventTrigger_Doukutu.enabled = true;
        eventTrigger_Kawabe.enabled = true;
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
            ////海岸選択
            case 0:
                if (button_Kaigan.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 0;
                    Choice_num = num;
                    Syupatsu.interactable = true;

                    image_Change.restartImage(0);
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled= false; 
                    eventTrigger_Kakou.enabled= false;  
                    eventTrigger_Sangaku.enabled= false;    
                    eventTrigger_Forest.enabled= false; 

                    button_Doukutu.enabled = false;
                    button_Forest.enabled=false;
                    button_Kaigan.enabled=false;    
                    button_Kakou.enabled=false;
                    button_Kawabe.enabled=false;
                    button_Sangaku.enabled=false;


                }
                break;
            ////森選択
            case 1:
                if (button_Forest.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 1;
                    Choice_num = num;
                    image_Change.restartImage(1);

                    Syupatsu.interactable = true;
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled = false;
                    eventTrigger_Kakou.enabled = false;
                    eventTrigger_Sangaku.enabled = false;
                    eventTrigger_Forest.enabled = false;
                    button_Doukutu.enabled = false;
                    button_Forest.enabled = false;
                    button_Kaigan.enabled = false;
                    button_Kakou.enabled = false;
                    button_Kawabe.enabled = false;
                    button_Sangaku.enabled = false;

                }
                break;
            ////川辺選択
            case 2:
                if (button_Kawabe.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 2;
                    Choice_num = num;
                    image_Change.restartImage(2);
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled = false;
                    eventTrigger_Kakou.enabled = false;
                    eventTrigger_Sangaku.enabled = false;
                    eventTrigger_Forest.enabled = false;
                    button_Doukutu.enabled = false;
                    button_Forest.enabled = false;
                    button_Kaigan.enabled = false;
                    button_Kakou.enabled = false;
                    button_Kawabe.enabled = false;
                    button_Sangaku.enabled = false;

                    Syupatsu.interactable = true;

                }
                break;
            ////山岳選択
            case 3:
                if (button_Sangaku.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 3;
                    Choice_num = num;
                    image_Change.restartImage(3);
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled = false;
                    eventTrigger_Kakou.enabled = false;
                    eventTrigger_Sangaku.enabled = false;
                    eventTrigger_Forest.enabled = false;
                    button_Doukutu.enabled = false;
                    button_Forest.enabled = false;
                    button_Kaigan.enabled = false;
                    button_Kakou.enabled = false;
                    button_Kawabe.enabled = false;
                    button_Sangaku.enabled = false;

                    Syupatsu.interactable = true;

                }
                break;
            ////火口選択
            case 4:
                if (button_Kakou.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 4;
                    Choice_num = num;
                    image_Change.restartImage(4);
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled = false;
                    eventTrigger_Kakou.enabled = false;
                    eventTrigger_Sangaku.enabled = false;
                    eventTrigger_Forest.enabled = false;
                    button_Doukutu.enabled = false;
                    button_Forest.enabled = false;
                    button_Kaigan.enabled = false;
                    button_Kakou.enabled = false;
                    button_Kawabe.enabled = false;
                    button_Sangaku.enabled = false;

                    Syupatsu.interactable = true;

                }
                break;
            ////洞窟選択
            case 5:
                if (button_Doukutu.onClick != null)
                {
                    Debug.Log(("シーン先は" + num));
                    num = 5;
                    Choice_num = num;
                    image_Change.restartImage(5);
                    eventTrigger_Kaigan.enabled = false;
                    eventTrigger_Doukutu.enabled = false;
                    eventTrigger_Kawabe.enabled = false;
                    eventTrigger_Kakou.enabled = false;
                    eventTrigger_Sangaku.enabled = false;
                    eventTrigger_Forest.enabled = false;
                    button_Doukutu.enabled = false;
                    button_Forest.enabled = false;
                    button_Kaigan.enabled = false;
                    button_Kakou.enabled = false;
                    button_Kawabe.enabled = false;
                    button_Sangaku.enabled = false;

                    Syupatsu.interactable = true;

                }
                break;
        }

    }
    public void LoadScene_each()
    {
        if (Choice_num == 0)
        {
            SceneManager.LoadScene(nextScene[Choice_num]);

        }
        else if (Choice_num == 1)
        {
            SceneManager.LoadScene(nextScene[Choice_num]);

        }
        else if (Choice_num == 2)
        {
            SceneManager.LoadScene(nextScene[Choice_num]);

        }
        else if (Choice_num == 3)
        {
            SceneManager.LoadScene(nextScene[Choice_num]);
        }
        else if (Choice_num == 4) 
        {
            SceneManager.LoadScene(nextScene[Choice_num]);

        }
        else if (Choice_num == 5)
        {
            SceneManager.LoadScene(nextScene[Choice_num]);
        }


    }
    public void Cancell()
    {
        Panel.SetActive(false);
    }



}
