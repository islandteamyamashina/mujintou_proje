using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
    [Space,SerializeField,Header("�����ɓo�^�����֐����e�L�X�g�I�����Ɉ��Ă΂�܂�")] 
    UnityEvent EndEvent;


    Text text;
    TextGenerator generator;

    int str_range = 0;//�������ڂ܂ŕ\�����邩
    int str_page = 0;//strs��index
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
            //�f�t�H���g�l��min��菬�����ꍇ�f�t�H���g��min��min���f�t�H���g��
            (default_font_size, min_font_size) = (min_font_size, default_font_size);
        }

        //�e�L�X�g���N���b�N�����Ƃ���OnClick�֐����Ă΂��悤�ɂ���ݒ�
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
            UpdateFontSize(0,default_font_size);//����t�H���g�T�C�Y�̌���A�Ȍ�̓y�[�W�ς�邲��
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
            //�ċA�֐��Ƃ��Ă̎g�p
            UpdateFontSize(page, newSize - (default_font_size - min_font_size) / Partition_Num);
        }
        else
        {
            text.text = "";
            return;//�e�L�X�g���ׂĕ\���\��Font�T�C�Y
            
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
                UpdateFontSize(str_page,default_font_size);

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
        EndEvent.Invoke();
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        eventTrigger.triggers.Clear();
    }
}
