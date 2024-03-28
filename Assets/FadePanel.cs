using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanel :MonoBehaviour
{
    private void Start()
    {
        PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

}


