using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI   ;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackLog : MonoBehaviour
{
    [SerializeField] Text BackLogText;
    [SerializeField] Image BackLogBG;
    [SerializeField] GameObject BackLogMain;
    [SerializeField] Button BackLogButton;


    void Start()
    {
        BackLogText.text = "";


        //EventTrigger eventTrigger = GetComponent<EventTrigger>();
        //EventTrigger.Entry entry = new EventTrigger.Entry();
        //entry.eventID = EventTriggerType.Deselect;
        //entry.callback.AddListener((data) => { OnCancel(); });
        //eventTrigger.triggers.Add(entry);


        if (BackLogButton)
        {
            Button.ButtonClickedEvent clickedEvent = new Button.ButtonClickedEvent();
            clickedEvent.AddListener(OnBackLogButtonDown);
            BackLogButton.onClick = clickedEvent;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  AddTextToBackLog(string   str)
    {
        BackLogText.text += str + "\n";
    }

    public Text GetBackLogText()
    {
        return BackLogText;
    }

    public void OnBackLogButtonDown()
    {
       
        BackLogMain.SetActive(!BackLogMain.activeSelf);
    }

    void ShowBackLog(bool b)
    {
        BackLogMain.SetActive(b);
    }
    void SwitchBackLogEnabled()
    {
        BackLogMain.SetActive(!BackLogMain.activeSelf);
    }

}
