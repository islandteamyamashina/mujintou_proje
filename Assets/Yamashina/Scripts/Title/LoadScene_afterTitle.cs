using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene_afterTitle : MonoBehaviour
{
    private void Start()
    {
        if (fade.feadout_f == false)
        {
            PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Audiovolume.instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }
    }
    [SerializeField] Fade fade;
    public void Load(int num)
    {
        DataManager.Instance.Load();

        fade.scene_name_num = num;
        fade.feadout_f = true;
        //GameObject.Find("MaintoInventory").

    }
}

