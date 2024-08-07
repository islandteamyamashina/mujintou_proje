using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHLModel : MonoBehaviour
{
    //これmodelじゃなくてPresenterだわ
    //Playerinfo --> model
    //Image view --> view
    //this --> presenter
    //PlayerinfoのFireをReactivePropertyとして公開するとなお良き

    [SerializeField]
    ImageViewWithSprites image_view;

    enum EBL_Situation
    {
        DayTimeNoFire = 0,
        DayTimeOnFire,
        NightNoFire,
        NightOnFire,
    }

    EBL_Situation situation = EBL_Situation.DayTimeNoFire;
    protected void Awake()
    {

        //パネル関係

        UpdateImage();
        PlayerInfo.Instance.OnFireSet += UpdateImage;

    }
    private void OnDestroy()
    {
        if (PlayerInfo.InstanceNullable)
        {
            PlayerInfo.Instance.OnFireSet -= UpdateImage;

        }
    }



    void UpdateImage()
    {
        var info = PlayerInfo.Instance;
        if (info.Day.isDayTime)
        {
            if (info.Fire > 0) situation = EBL_Situation.DayTimeOnFire;
            else situation = EBL_Situation.DayTimeNoFire;
        }
        else
        {
            if (info.Fire > 0) situation = EBL_Situation.NightOnFire;
            else situation = EBL_Situation.NightNoFire;
        }

        image_view.SetImageSprite((int)situation);
    }


}
