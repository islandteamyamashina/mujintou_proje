using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextCollorChange_op : MonoBehaviour
{
    [SerializeField] Text Text;

    // Start is called before the first frame update
    public void TextChangeOptionRestart()
    {
        string colorString = "#FFFFFF"; // �ԐF��16�i��������
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // �V����Color���쐬
        Text.color = newColor;

    }
    public void Text_ColorChange_option()
        {
            string colorString = "#00ffff"; // �ԐF��16�i��������
            Color newColor;
            ColorUtility.TryParseHtmlString(colorString, out newColor); // �V����Color���쐬
            Text.color = newColor;
        }
    
}
