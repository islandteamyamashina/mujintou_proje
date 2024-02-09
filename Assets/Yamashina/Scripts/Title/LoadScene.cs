using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
   [SerializeField] string sceneName1;
    [SerializeField] Fade fade;


    public void Start()
    {
       // fade.feadout_f = false;
    }
    // Update is called once per frame
    public void Text_of_each_places(int num)
    {
        switch (num)
        {
            case 0:
                fade.feadout_f = true;
                SceneManager.LoadScene(sceneName);
                break;
            case 1:
                fade.feadout_f = true;

                SceneManager.LoadScene(sceneName1);
                break;
        }
    }
}

