using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Choice_Ending : MonoBehaviour
{
    private int Choice_End;
    // Start is called before the first frame update
    void Start()
    {
        Choice_End = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Choice_Click()
    {
        Choice_End++;
        Debug.Log("ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½" +  Choice_End);
    }

    public void GoTo_Click()
    {
        if (Choice_End % 3 == 0)
        {
            SceneManager.LoadScene("Normal_Ending");
        }
        else if (Choice_End % 3 == 1)
        {
            SceneManager.LoadScene("True_Ending");
        }
        else if(Choice_End % 3 == 2)
        {
            SceneManager.LoadScene("Bad_Ending");
        }
    }
}
