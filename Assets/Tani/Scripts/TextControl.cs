using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class TextControl : MonoBehaviour
{


    [SerializeField,Header("文字の増やす間隔")]
    float interval = 0.15f;
    [SerializeField,Header("このリストに含まれた文字列が画面に出力されます")]
    protected List<string> strs;
    [SerializeField,Header("文字列の長さに応じて自動でフォントサイズを変更します")]
    bool auto_font_size = true;
    [SerializeField]
    int min_font_size = 80;
    [SerializeField]
    int Partition_Num = 8;
    [Space,SerializeField,Header("ここに登録した関数がテキスト終了時に一回呼ばれます")] 
    UnityEvent EndEvent;


    Text text;
    TextGenerator generator;

    int str_range = 0;//何文字目まで表示するか
    int str_page = 0;//strsのindex
    int default_font_size;
    float time_sum = 0;
    bool is_text_end = false;
    bool is_first_font_updated = false;
    Vector2 text_size;
    
    virtual protected void Start()
    {
        text = GetComponent<Text>();
        generator = new TextGenerator();

        default_font_size = text.fontSize;
        text_size = new Vector2(text.rectTransform.rect.width, text.rectTransform.rect.height);
        if(default_font_size < min_font_size)
        {
            //デフォルト値がminより小さい場合デフォルトをminにminをデフォルトに
            (default_font_size, min_font_size) = (min_font_size, default_font_size);
        }

        //テキストをクリックしたときにOnClick関数が呼ばれるようにする設定
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnClick(); });
        eventTrigger.triggers.Add(entry);


        
    }


    virtual protected void Update()
    {
        if (!is_first_font_updated && auto_font_size )
        {
            UpdateFontSize(0,default_font_size);//初回フォントサイズの決定、以後はページ変わるごと
            is_first_font_updated = true;
        }
        if (strs.Count == 0) return;


        time_sum += Time.deltaTime;
        if(time_sum > interval)
        {
            time_sum = 0;
            if(str_range < strs[str_page].Length)
            {
                str_range++;
                UpdateText(str_range);
            }
            else
            {
                is_text_end = true;
            }
        }
    }

    void UpdateText(int count)
    {
        text.text = strs[str_page][..count];
    }

    void UpdateFontSize(int page,int newSize)
    {
        if (!auto_font_size) return;

        generator.Invalidate();
        text.fontSize = newSize;
        text.text = strs[str_page];

        TextGenerationSettings settings 
            = text.GetGenerationSettings(text_size);
        generator.Populate(text.text, settings);


        if (generator.characterCountVisible != strs[page].Length)
        {
            if(newSize < min_font_size)
            {
                text.fontSize = min_font_size;
                Debug.LogError("text Overflow");
                return;
            } 
            //再帰関数としての使用
            UpdateFontSize(page, newSize - (default_font_size - min_font_size) / Partition_Num);
        }
        else
        {
            text.text = "";
            return;//テキストすべて表示可能なFontサイズ
            
        }

        text.text = "";
    }
    void OnClick()
    {
        //文章が終わっていないときは文章を全て表示
        if (!is_text_end)
        {
            str_range = strs[str_page].Length;
            UpdateText(str_range);
        }
        else
        {
            //文章が終わっているときは次のページ

            str_page++;
            if (str_page != strs.Count)
            {
                is_text_end = false;
                str_range = 0;
                time_sum = 0;
                UpdateFontSize(str_page,default_font_size);

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
        EndEvent.Invoke();
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        eventTrigger.triggers.Clear();
    }
}
