using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange_kyoten :Image_Method
{
    int image_num;
    public KyotenToOtherspace kyotenToOtherspace;

    public Image TakibiImage;
     [SerializeField] public Sprite image;
    [SerializeField] public Sprite Image2;
     void Start()
    {
       
        image_num = 0;
        if (kyotenToOtherspace.takibi <= 0)
        {
            TakibiImage.sprite = Image2;
        }
        else
        {
            TakibiImage.sprite = image;
        }
        // PutImage(image);
    }
    void Update()
    {
        if(kyotenToOtherspace.takibi_f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(image_num == 0 && kyotenToOtherspace.takibi <= 0)
                {
                    TakibiImage.sprite = Image2;
                    //PutImage(Image2);
                    //Remove_Image(image);
                    image_num = 1;
                    
                }

             else if (image_num == 1 )
                {
                    TakibiImage.sprite = image;
                    //PutImage(image);
                    //Remove_Image(Image2);
                    image_num = 0;
                    kyotenToOtherspace.takibi = 100;
                    Debug.Log(kyotenToOtherspace.takibi);
                }

            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                kyotenToOtherspace.takibi = 0;
                Debug.Log(kyotenToOtherspace.takibi);
            }
        }

    }

}
