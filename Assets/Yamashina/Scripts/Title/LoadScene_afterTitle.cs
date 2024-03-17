using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene_afterTitle : MonoBehaviour
{
    [SerializeField] Fade fade;
    public void Load(int num)
    {
        DataManager.Instance.Load();

        fade.scene_name_num = num;
        fade.feadout_f = true;
        //GameObject.Find("MaintoInventory").

    }
}

