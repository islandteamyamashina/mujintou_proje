using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OffTirgger : MonoBehaviour
{
    [SerializeField] GameObject Trigger;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfo.Instance.Inventry.GetVisibility())
        {
            Trigger.SetActive(false);
        }
        else
        {
            Trigger.SetActive(true);
        }
    }
}
