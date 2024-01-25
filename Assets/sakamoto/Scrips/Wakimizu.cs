using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wakimizu : MonoBehaviour
{
    [SerializeField] public NewItem enptyBottle;
    [SerializeField] public NewItem waterBottle;

    
    public bool wakimizu_f;
    // Start is called before the first frame update
    void Start()
    {
        wakimizu_f = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrinkWater()
    {
        Debug.Log("飲む前の水分は" + PlayerInfo.Instance.Thirst);
        if (wakimizu_f)
        {
            PlayerInfo.Instance.Thirst += 20;
            wakimizu_f = false;
        }
        else
        {
            Debug.Log("何も起こらなかった。");
        }

        Debug.Log("飲んだ後の水分は" + PlayerInfo.Instance.Thirst);

    }

    public void DrawWater()
    {
        if (wakimizu_f)
        {
            if (enptyBottle.CurrentStackCount >= 1)
            {
                waterBottle.CurrentStackCount++;

                enptyBottle.CurrentStackCount--;
                wakimizu_f = false;
            }
        }
        else
        {
            Debug.Log("何も起こらなかった。");
        }


    }
}
