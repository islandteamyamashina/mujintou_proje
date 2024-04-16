using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePanel : PanelBase
{
    [SerializeField]
    List<GameObject> fire_panels;


    [SerializeField]
    GameObject main;
    [SerializeField]
    Button ToMakeFire;
    [SerializeField]
    Button ToAddFire;
    [SerializeField]
    Button ToCooking;
    [SerializeField]
    Image fire_icon_front;
    [SerializeField]
    Image fire_icon_middle;

    private void OnEnable()
    {
        SetFirePanelActivate(0);
        fire_icon_middle.fillAmount = 0;
        
    }
    private void FixedUpdate()
    {
        ToMakeFire.gameObject.SetActive(PlayerInfo.Instance.Fire == 0);
        ToAddFire.gameObject.SetActive(PlayerInfo.Instance.Fire != 0);
        fire_icon_front.fillAmount = PlayerInfo.Instance.Fire / 100.0f;
        ToCooking.interactable = PlayerInfo.Instance.Fire != 0;
    }

    public void SetFirePanelActivate(int index)
    {
        for (int i = 0; i < fire_panels.Count; i++)
        {
            fire_panels[i].SetActive(false);
        }
        fire_panels[index].SetActive(true);
    }


}
