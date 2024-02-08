using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
//using System.Diagnostics;

public class Story_Text : Text_Method
{
    [SerializeField] StoryData storyData;
    [SerializeField] string sceneName;
    public multiAudio multiAudio;
    int line_num;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke();
        line_num = 1;
        Text_Disply(storyData.FarstLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            multiAudio.SE2();
            Invoke("Next_Text", 1.0f);
        }
    }
    void Next_Text()
    {
        line_num++;
        if (line_num == 2)
        {
            if (storyData.ScondLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
            Text_Disply(storyData.ScondLine);

            }

        }
        if (line_num == 3)
        {

            if (storyData.ThirdLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
            Text_Disply(storyData.ThirdLine);

            }

        }
        if (line_num == 4)
        {
            if (storyData.FourthLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.FourthLine);

        }
        if (line_num == 5)
        {
            if (storyData.FifthLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.FifthLine);

        }
        if (line_num == 6)
        {
            if (storyData.SixthLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.SixthLine);

        }
        if (line_num == 7)
        {
            if (storyData.SeventhLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.SeventhLine);

        }
        if (line_num == 8)
        {
            if (storyData.EightLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.EightLine);

        }
        if (line_num == 9)
        {
            if (storyData.NinethLine == "NULL")
            {
                SceneManager.LoadScene(sceneName);
            }
            Text_Disply(storyData.NinethLine);

        }
        if (line_num == 10)
        {
            Text_Disply(storyData.TenthLine);
            Debug.Log("�^�C�g���ɖ߂�");
        }


    }



    private void OnDestroy()
    {
        // Destroy���ɓo�^����Invoke�����ׂăL�����Z��
        CancelInvoke();
    }
    public void Invoke()
    {
        Invoke(nameof(LoadingScene), 2.5f);

    }
    public void LoadingScene()//Scene�̑J��
    {
        SceneManager.LoadScene(sceneName);

    }
}
