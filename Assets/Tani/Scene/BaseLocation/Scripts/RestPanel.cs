using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestPanel : PanelBase
{
    [SerializeField]
    Button rest_button;
    [SerializeField]
    int health_change = 30;
    [SerializeField]
    int hunger_change = -30;
    [SerializeField]
    int thirst_change = -30;

    protected override void Start()
    {

        SetSortOrder(OrderOfUI.NormalPanel);
        rest_button.onClick.AddListener(Rest);
    }


    protected override void Update()
    {

    }

    void Rest()
    {
        Fading fading = (Fading)GameObject.FindAnyObjectByType(typeof(Fading));
        if (!fading) return;
        fading.Fade(Fading.type.FadeOut);
        fading.OnFadeEnd.AddListener(() =>
        {
            var info = PlayerInfo.Instance;
            info.Health += health_change;
            info.Hunger += hunger_change;
            info.Thirst += thirst_change;
            info.ActionValue += Mathf.CeilToInt(info.MaxActionValue / 2.0f);
            info.DoAction();
            info.SavePalyerData();
            BaseLocationDaytimeController controller = (BaseLocationDaytimeController)GameObject.FindAnyObjectByType(typeof(BaseLocationDaytimeController));
            controller.ChangeBaseLocation();
        });

        
        
    }

}
