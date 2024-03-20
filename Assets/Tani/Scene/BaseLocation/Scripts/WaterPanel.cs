using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterPanel : PanelBase
{
    [SerializeField]
    Text water_value_text;

    // Start is called before the first frame update
    protected override void Start()
    {

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        water_value_text.text = "ˆù—¿’l : " + PlayerInfo.Instance.Thirst.ToString() ;
    }
}
