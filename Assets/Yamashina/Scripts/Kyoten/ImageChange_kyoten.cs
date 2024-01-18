using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange_kyoten :Image_Method
{
    
    public KyotenToOtherspace kyotenToOtherspace;

    [SerializeField] Sprite image;
    [SerializeField] Sprite Image2;
     void Start()
    {
        int image_num;
        PutImage(image);
    }
    void Update()
    {
        if(kyotenToOtherspace.takibi_f)
        {
            if (Input.GetMouseButton(0))
            {

            }
        }
    }

}
