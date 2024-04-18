using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestPanel : PanelBase
{
    [SerializeField]
    Button rest_button;
    [SerializeField]
    Text RestButtonText;
    [SerializeField]
    Text HealthChangeText;
    [SerializeField]
    int health_change = 30;
    [SerializeField]
    int hunger_change = -30;
    [SerializeField]
    int thirst_change = -30;

    PlayerInfo info;
    protected override void Start()
    {
        info = PlayerInfo.Instance;
        SetSortOrder(OrderOfUI.NormalPanel);
        rest_button.onClick.AddListener(Rest);
    }


    protected override void Update()
    {
        int prev = info.Health;
        HealthChangeText.text = $"<b>{prev}%  >>  {Mathf.Clamp(prev + (info.Day.isDayTime ? (int)(health_change * 1.5f) : health_change), 0, 100)}%</b>";
    }
    private void OnEnable()
    {
        RestButtonText.text = PlayerInfo.Instance.Day.isDayTime ? "–é‚Ü‚Å‹x‚Þ" : "‡–°‚ð‚Æ‚é";
    }

    void Rest()
    {
        Fading fading = (Fading)GameObject.FindAnyObjectByType(typeof(Fading));
        if (!fading) return;
        fading.Fade(Fading.type.FadeOut);
        fading.OnFadeEnd.AddListener(() =>
        {
            var info = PlayerInfo.Instance;
            info.Health += info.Day.isDayTime ?  (int)(health_change * 1.5f) : health_change;
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
