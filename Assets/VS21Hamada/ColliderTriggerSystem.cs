using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerSystem : MonoBehaviour
{
    public enum Items
    {
        Stone,
        Wood,
        WoodEda,
    }
    public GameObject[] craftPrefab;
    public GameObject CraftSlotL, CraftSlotR;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  レシピ表から取得
        if (CraftSlotL != null && CraftSlotR != null)
        {
            switch (CraftSlotL.name)
            {
                //  左が石
                case "Stone":
                    switch (CraftSlotR.name)
                    {
                        case "WoodEda":
                            //  石の斧
                            break;
                        default:
                            //  何も作成できない
                            break;
                    }
                    break;
                case "WoodEda":
                    switch (CraftSlotR.name)
                    {
                        case "Stone":
                            //  石の斧
                            break;
                        default:
                            //  何もできない
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
