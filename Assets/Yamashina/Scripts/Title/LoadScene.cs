using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
  
    [SerializeField] Fade fade;


    public void Start()
    {
       // fade.feadout_f = false;
    }
    // Update is called once per frame
    public void Text_of_each_places(int num=0)
    {
        fade.scene_name_num = num;
                fade.feadout_f = true;
               
    }
}

