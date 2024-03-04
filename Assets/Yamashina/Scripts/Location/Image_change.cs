using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Image_change : MonoBehaviour
{

    //[SerializeField] public GameObject image;
    [SerializeField] public GameObject hightlightImage;
    public  void Start()
    {
       // image.SetActive(false);
        hightlightImage.SetActive(false);
       
    }

    public  void ImageChange()
    {
        //image.SetActive(true);
        hightlightImage.SetActive(false);


    }

    public  void  restartImage()
    {
       // image.SetActive(false);
        hightlightImage.SetActive(true);
    }

   
   
}
