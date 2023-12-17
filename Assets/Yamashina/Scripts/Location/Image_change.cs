using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_change : MonoBehaviour
{

    [SerializeField] public GameObject image;

    public void Start()
    {
        image.SetActive(false);
    }

    public void ImageChange()
    {
        image.SetActive(true);
    }

    public void restartImage()
    {
        image.SetActive(false);
    }
}
