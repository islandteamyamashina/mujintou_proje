using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_menu : TitleMenu
{
    // Start is called before the first frame update
   
     public GameObject Option;
    GameObject clone;

    // ���肳�ꂽ�Ƃ��̓���
    public override IEnumerator Select()
    {
        
    
        // �����ɂQ�b�҂�
        yield return new WaitForSeconds(2.0f);
    clone = Instantiate(Option);
        // �I�v�V������������܂Ń��[�v
        while (clone)
        {
            yield return null;
        }
    }

}

