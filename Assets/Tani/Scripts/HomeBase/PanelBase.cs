using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    [SerializeField]
    GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(parent.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnabled(bool enabled)
    {
        gameObject.SetActive(enabled);
    }

    public void SwitchEnabaled()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
