using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using System.Diagnostics;

public class Story_Text : Text_Method
{
    [SerializeField] StoryData storyData;
    int line_num;
    // Start is called before the first frame update
    void Start()
    {
        line_num = 1;
        Text_Disply(storyData.FarstLine);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            line_num++;
            if (line_num == 2)
            {
                Text_Disply(storyData.ScondLine);
            }
            if (line_num == 3)
            {
                Text_Disply(storyData.ThirdLine);
                if(storyData.ThirdLine == "NULL")
                {
                    Debug.Log("ƒ^ƒCƒgƒ‹‚É–ß‚é");
                }
            }
            if (line_num == 4)
            {
                Text_Disply(storyData.FourthLine);
            }
            if (line_num == 5)
            {
                Text_Disply(storyData.FifthLine);
            }
            if (line_num == 6)
            {
                Text_Disply(storyData.SixthLine);
            }
            if (line_num == 7)
            {
                Text_Disply(storyData.SeventhLine);
            }
            if (line_num == 8)
            {
                Text_Disply(storyData.EightLine);
            }
            if (line_num == 9)
            {
                Text_Disply(storyData.NinethLine);
            }
            if (line_num == 10)
            {
                Text_Disply(storyData.TenthLine);
            }


        }

    }
}
