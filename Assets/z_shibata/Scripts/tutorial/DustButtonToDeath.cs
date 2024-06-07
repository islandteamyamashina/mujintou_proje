using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DustButtonToDeath : MonoBehaviour
{
    GameObject inv;
    [SerializeField] GameObject massage;
    GameObject a;
    GameObject dustBox;
    [SerializeField] GameObject awayButton;
    bool once = false;
    private void Start()
    {
        inv = PlayerInfo.Instance.Inventry.gameObject;
    }
    private void Update()
    {
        if (inv.active == true)
        {
            awayButton.SetActive(true);
            if (once == false)
            {
                FindDustBox();
            }
        }
        if(inv.active == false)
        {
            awayButton.SetActive(false);
        }
    }
    public void SetMassage()
    {
        a.SetActive(true);
    }
    void FindDustBox()
    {
        Debug.Log("find");
        once = true;
        //awayButton = GameObject.Find("trowaway");
        dustBox = GameObject.Find("dustBox");
        awayButton.GetComponent<Button>().onClick.AddListener(() =>
        { 
            InstaMassage();
            GameObject.FindAnyObjectByType<anotherSoundPlayer>().GetComponent<anotherSoundPlayer>().ChooseSongs_SE(4);
        });
    }
    public void InstaMassage()
    {
        Debug.Log("button");
        var b = dustBox.GetComponent<SlotManager>().GetSlotItem(0).Value.id;
        Debug.Log(b);
        var c = Items.Item_ID.EmptyObject;
        if (b != c)
        {
            Instantiate(massage);
        }
        
    }
}
