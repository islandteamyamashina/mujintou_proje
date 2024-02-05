using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusImage : MonoBehaviour
{
    [SerializeField] Image status_image;
    [SerializeField] Status_Type status_type = Status_Type.Health;
    RectTransform rect;

    float init_mask_height = 0;
    public enum Status_Type
    {
        Health,Hunger,Thirst
    }
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        init_mask_height = rect.rect.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
