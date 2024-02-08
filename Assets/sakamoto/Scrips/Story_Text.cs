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
    [SerializeField] string     sceneName;
    public multiAudio multiAudio;
    int line_num;
    // Start is called before the first frame update
    void Start()
    {
        Invoke();
        line_num = 1;
        Text_Disply(storyData.FarstLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            multiAudio.SE2();

            line_num++;
            if (line_num == 2)
            {
                Text_Disply(storyData.ScondLine);
                if (storyData.ScondLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 3)
            {
                Text_Disply(storyData.ThirdLine);
                 
                if(storyData.ThirdLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
            if (line_num == 4)
            {
                Text_Disply(storyData.FourthLine);
                if (storyData.FourthLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 5)
            {
                Text_Disply(storyData.FifthLine);
                if (storyData.FifthLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 6)
            {
                Text_Disply(storyData.SixthLine);
                if (storyData.SixthLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 7)
            {
                Text_Disply(storyData.SeventhLine);
                if (storyData.SeventhLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 8)
            {
                Text_Disply(storyData.EightLine);
                if (storyData.EightLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 9)
            {
                Text_Disply(storyData.NinethLine);
                if (storyData.NinethLine == "NULL")
                {
                    SceneManager.LoadScene(sceneName);
                }

            }
            if (line_num == 10)
            {
                Text_Disply(storyData.TenthLine);
                    Debug.Log("ƒ^ƒCƒgƒ‹‚É–ß‚é");
            }
            

        }

    }
    private void OnDestroy()
    {
        // DestroyŽž‚É“o˜^‚µ‚½Invoke‚ð‚·‚×‚ÄƒLƒƒƒ“ƒZƒ‹
        CancelInvoke();
    }
    public void Invoke()
    {
        Invoke(nameof(LoadingScene), 2.5f);

    }
    public void LoadingScene()//Scene‚Ì‘JˆÚ
    {
        SceneManager.LoadScene(sceneName);

    }
}
