using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusImage : MonoBehaviour
{
    Image image;
    [SerializeField] Status_Type status_type = Status_Type.Health;
    PlayerInfo info;


    public enum Status_Type
    {
        Health,Hunger,Thirst
    }
    // Start is called before the first frame update
    void Start()
    {
        info = PlayerInfo.Instance;
        image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        
        switch (status_type)
        {
            case Status_Type.Health:
                image.fillMethod = Image.FillMethod.Radial360;
                image.fillOrigin = 2;
                image.fillClockwise = false;
                
                break;
            case Status_Type.Hunger:
                image.fillMethod = Image.FillMethod.Vertical;
                
                break;

            case Status_Type.Thirst:
                image.fillMethod = Image.FillMethod.Vertical;
                break;
        }

    }


    void Update()
    {
        
        image.fillAmount = info.GetStatusPercent((int)status_type);
        switch (status_type)
        {
            case Status_Type.Health:
                
                break;
            case Status_Type.Hunger:
                

                break;
            case Status_Type.Thirst:
                
                if (image.fillAmount <= 0.45f)
                {
                    image.color = new Color(150 / 255.0f, 85 / 255.0f, 20 / 255.0f);
                
                }
                else
                {
                    image.color = new Color(46 / 255.0f, 167 / 255.0f, 224 / 255.0f);
                }
                break;
        }
        
    }
}
