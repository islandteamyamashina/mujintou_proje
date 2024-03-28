using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testButton : MonoBehaviour
{

    [SerializeField]
    Button button;
    [SerializeField]
    Items.Item_ID id;

    // Start is called before the first frame update
    void Start()
    {
        (Items.Item_ID id,int amount)? data =  PlayerInfo.Instance.Inventry.GetSlotItem(3);
        if (data.HasValue)
        {
            
        }

        PlayerInfo.Instance.Inventry.GetItem((Items.Item_ID)25, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
