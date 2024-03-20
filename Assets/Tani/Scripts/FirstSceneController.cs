using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    [SerializeField]
    GameObject gm;
    [SerializeField]
    int i = 0;
    void Start()
    {
        if(i == 0)
            print((int)(i - (5 / 2.0f)));


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gm.transform.Translate(100 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gm.transform.Translate( -100 * Time.deltaTime, 0, 0);
        }


    }
    public void NextScene()
    {
        SceneManager.LoadScene(7);
    }

    
}
