using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class TextControl : MonoBehaviour
{




    [SerializeField,Header("文字の増やす間隔")]
    float interval = 0.15f;

    [SerializeField]
    protected List<string> strs;

    Text text;
    int str_range = 0;
    int str_page = 0;
    float time_sum = 0;
    bool is_text_end = false;

    virtual protected void Start()
    {
        text = GetComponent<Text>();
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnClick(); });
        eventTrigger.triggers.Add(entry);



    }


    virtual protected void Update()
    {
        time_sum += Time.deltaTime;
        if(time_sum > interval)
        {
            time_sum = 0;
            if(str_range < strs[str_page].Length)
            {
                str_range++;
                UpdateText(str_page, str_range);
            }
            else
            {
                is_text_end = true;
            }
        }
    }

    void UpdateText(int page,int count)
    {
        text.text = strs[page][..count];

    }
    void OnClick()
    {
        //文章が終わっていないときは文章を全て表示
        if (!is_text_end)
        {
            str_range = strs[str_page].Length;
            UpdateText(str_page, str_range);
        }
        else
        {
            //文章が終わっているときは次のページ
            is_text_end = false;
            str_page++;
            if (str_page != strs.Count)
            {
                str_range = 0;
                time_sum = 0;

            }
            else//次のページがなければ文章はそのまま、OnTextEndを発火
            {
                str_page = strs.Count - 1;
                OnTextEnd();
            }
        }
    }
    virtual protected void OnTextEnd()
    {
        Debug.Log("文章の終わり");
    }
}
