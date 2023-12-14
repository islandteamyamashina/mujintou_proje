using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{

    int Cursor = 0;
    public TitleMenu[] MenuTable;
    public SpriteRenderer CursorRenderer;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMenu();
    }

    // Update is called once per frame
    // Input更新
    IEnumerator UpdateInput()
    {
        // 開始時はスルー
        yield return null;

        // シーンが切り替わるまで無限ループ
        while (true)
        {
            int oldCursor = Cursor;
            int cursorMax = MenuTable.Length;

            if (Input.GetButtonDown("CursorUp"))
            {
                Cursor--;
            }
            else if (Input.GetButtonDown("CursorDown"))
            {
                Cursor++;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                yield return StartCoroutine(MenuTable[Cursor].Select());
            }

            // カーソルの制御
            if (Cursor < 0)
            {
                Cursor = MenuTable.Length - 1;
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

            yield return null;
        }
    }

    // メニューの更新
    void SetMenu()
    {
        // カーソルの位置を設定
        CursorRenderer.transform.position = [Cursor].transform.position;

    }

    // メニューの更新
    void UpdateMenu()
    {
        int cursor = 0;
        foreach (TitleMenu menu in MenuTable)
        {
            if (Cursor == cursor)
            {
                menu.On();

                // カーソルの位置を設定
                CursorRenderer.transform.position = menu.transform.position;
            }
            else
            {
                menu.Off();
            }

            ++cursor;
        }
    }
}

