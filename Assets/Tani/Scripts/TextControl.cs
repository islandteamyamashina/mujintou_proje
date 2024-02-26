using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class TextControl : MonoBehaviour
{


    [SerializeField,Header("�����̑��₷�Ԋu")]
    float interval = 0.15f;
    [SerializeField,Header("���̃��X�g�Ɋ܂܂ꂽ�����񂪉�ʂɏo�͂���܂�")]
    protected List<string> strs;
    [SerializeField,Header("������̒����ɉ����Ď����Ńt�H���g�T�C�Y��ύX���܂�")]
    bool auto_font_size = true;
    [SerializeField]
    int min_font_size = 80;
    [SerializeField]
    int Partition_Num = 8;

    Text text;
    TextGenerator generator = new TextGenerator();
    int str_range = 0;//�������ڂ܂ŕ\�����邩
    int str_page = 0;//strs��index
    float time_sum = 0;
    bool is_text_end = false;
    int defaul_font_size;
    bool is_first_font_updated = false;
    
    virtual protected void Start()
    {
        text = GetComponent<Text>();
        defaul_font_size = text.fontSize;
        if(defaul_font_size < min_font_size)
        {
            //�f�t�H���g�l��min��菬�����ꍇ�f�t�H���g��min��min���f�t�H���g��
            (defaul_font_size, min_font_size) = (min_font_size, defaul_font_size);
        }

        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnClick(); });
        eventTrigger.triggers.Add(entry);


        
    }


    virtual protected void Update()
    {
        if (!is_first_font_updated)
        {
            UpdateFontSize(0,defaul_font_size);//����t�H���g�T�C�Y�̌���A�Ȍ�̓y�[�W�ς�邲��
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
        generator.Invalidate();
        text.fontSize = newSize;
        text.text = strs[str_page];
        TextGenerationSettings settings = text.GetGenerationSettings(
            new Vector2(text.rectTransform.rect.width, text.rectTransform.rect.height));
        
        generator.Populate(text.text, settings);
        Debug.Log(text.text);
        Debug.Log(generator.characterCount + ":" +newSize);


        if (generator.characterCount != strs[page].Length)
        {
            if(newSize < min_font_size)
            {
                text.fontSize = min_font_size;
                Debug.LogError("text Overflow");
                return;
            } 
            UpdateFontSize(page, newSize - (defaul_font_size - min_font_size) / Partition_Num);
        }
        else
        {
            text.text = "";
            return;//�e�L�X�g���ׂĕ\��
            
        }

        text.text = "";
    }
    void OnClick()
    {
        //���͂��I����Ă��Ȃ��Ƃ��͕��͂�S�ĕ\��
        if (!is_text_end)
        {
            str_range = strs[str_page].Length;
            UpdateText(str_range);
        }
        else
        {
            //���͂��I����Ă���Ƃ��͎��̃y�[�W

            str_page++;
            if (str_page != strs.Count)
            {
                is_text_end = false;
                str_range = 0;
                time_sum = 0;
                UpdateFontSize(str_page,defaul_font_size);

            }
            else//���̃y�[�W���Ȃ���Ε��͂͂��̂܂܁AOnTextEnd�𔭉�
            {
                str_page = strs.Count - 1;
                OnTextEnd();
            }
        }
    }
    virtual protected void OnTextEnd()
    {
        Debug.Log("���͂̏I���");
    }
}
