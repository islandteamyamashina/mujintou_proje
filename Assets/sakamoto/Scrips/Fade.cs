using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fade : MonoBehaviour
{
    [SerializeField] GameObject feadPanal;
    Color color;
    int fead_time;
    public bool feadout_f;
    [SerializeField]string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        feadout_f = false;
        fead_time = 300;
        color = feadPanal.GetComponent<Image>().color;
        Debug.Log(feadPanal.GetComponent<Image>().color);
    }

    // Update is called once per frame
    void Update()
    {
        if (!feadout_f)
        {
           FeadIn();
        }
        if(feadout_f)
        {
            FeadOut(scene_name);
        }
        if(Input.GetKeyDown(KeyCode.A)) 
        {
            feadout_f = true;
            Debug.Log(feadout_f);
        }
        
    }
    void FeadIn()
    {
        if(!(color.a <= 0))
        {
            //Debug.Log(feadPanal.GetComponent<Image>().color);
            color.a -= 0.0015f;
            feadPanal.GetComponent<Image>().color = color;
            //Debug.Log(feadPanal.GetComponent<Image>().color);
            if(color.a <= 0)
            {
                feadPanal.SetActive(false);
            }

            
        }
    }
    void FeadOut(string scene_name)
    {
        feadPanal.SetActive(true);
        if((color.a < 1))
        {
            color.a += 0.0015f;
            feadPanal.GetComponent<Image>().color = color;
        }
        if(color.a >= 1)
        {
            SceneManager.LoadScene(scene_name);
        }
    }
}
