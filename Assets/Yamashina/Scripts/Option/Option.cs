using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    int Cursor = 0;                         // カーソル位置
    public Option_menuBase[] OptionTable;   // オプション項目を格納
    public SpriteRenderer CursorRenderer;   // カーソル用

    // Start is called before the first frame update
    void Start()
    {
        SetMenu();
    }

    // Update is called once per frame
    void Update()
    {
        int oldCursor = Cursor;
        int cursorMax = OptionTable.Length;

        if (Input.GetButtonDown("CursorUp"))
        {
            Cursor--;
        }
        else if (Input.GetButtonDown("CursorDown"))
        {
            Cursor++;
        }
        else if (Input.GetButtonDown("CursorLeft"))
        {
            OptionTable[Cursor].Left();
        }
        else if (Input.GetButtonDown("CursorRight"))
        {
            OptionTable[Cursor].Right();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            OptionTable[Cursor].Select();
        }

        // カーソルの制御
        if (Cursor < 0)
        {
            Cursor = OptionTable.Length - 1;
        }
        if (Cursor >= cursorMax)
        {
            Cursor = 0;
        }

        // カーソルに変更があったら
        if (Cursor != oldCursor)
        {
            SetMenu();
        }
    }

    // メニューの更新
    void SetMenu()
    {
        // カーソルの位置を設定
        CursorRenderer.transform.position = OptionTable[Cursor].transform.position;

    }
}