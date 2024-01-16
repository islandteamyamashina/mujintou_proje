using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChange_kyoten : MonoBehaviour
{
    [SerializeField] public GameObject image;
    [SerializeField] public GameObject hightlightImage;

    public  void Start()
    {
        image.SetActive(false);
        hightlightImage.SetActive(true);

    }

    public void ImageChange1()
    {
        image.SetActive(true);
        hightlightImage.SetActive(false);


    }

    public void restartImage2()
    {
        image.SetActive(false);
        hightlightImage.SetActive(true);

    }
}
