using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour

{
    [SerializeField] Text Text;
    // Start is called before the first frame update
    void Start()
    {
        string colorString = "#4D4D4D"; // 赤色の16進数文字列
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
        Text.color = newColor;

    }
    public void TextChangeOptionRestart()
    {
        string colorString = "#FFFFFF"; // 赤色の16進数文字列
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
        Text.color = newColor;

    }
    public void Text_ColorChange()
    {
        string colorString = "#1B1464"; // 赤色の16進数文字列
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
        Text.color = newColor;
    }
    public void Text_ColorRestart()
    {
        string colorString = "#4D4D4D"; // 赤色の16進数文字列
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
        Text.color = newColor;
    }


    public void Text_ColorChange_option()
    {
        string colorString = "#00ffff"; // 赤色の16進数文字列
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
        Text.color = newColor;
    }
}
