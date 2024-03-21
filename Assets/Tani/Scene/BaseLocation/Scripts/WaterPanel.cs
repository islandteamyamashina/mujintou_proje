using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPanel : PanelBase
{
    [SerializeField]
    Text water_value_text;
    [SerializeField]
    Text spring_water_text;


    // Start is called before the first frame update
    protected override void Start()
    {

        SetSortOrder(OrderOfUI.NormalPanel);

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        water_value_text.text = "ˆù—¿’l : " + PlayerInfo.Instance.Thirst.ToString() ;
        spring_water_text.text = "—N‚«… : " + PlayerInfo.Instance.Water.ToString();
    }

    public void DrinkWater()
    {
        var info = PlayerInfo.Instance;
        if(info.Thirst + info.Water >= 100)
        {
            info.Water -= 100 - info.Thirst;
            info.Thirst = 100;
        }
        else
        {
            info.Thirst += info.Water;
            info.Water = 0;
        }
    }
}
