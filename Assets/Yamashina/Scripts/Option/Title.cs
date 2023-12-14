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
    // Input�X�V
    IEnumerator UpdateInput()
    {
        // �J�n���̓X���[
        yield return null;

        // �V�[�����؂�ւ��܂Ŗ������[�v
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

            // �J�[�\���̐���
            if (Cursor < 0)
            {
                Cursor = MenuTable.Length - 1;
            }
            if (Cursor >= cursorMax)
            {
                Cursor = 0;
            }

            // �J�[�\���ɕύX����������
            if (Cursor != oldCursor)
            {
                SetMenu();
            }

            yield return null;
        }
    }

    // ���j���[�̍X�V
    void SetMenu()
    {
        // �J�[�\���̈ʒu��ݒ�
        CursorRenderer.transform.position = [Cursor].transform.position;

    }

    // ���j���[�̍X�V
    void UpdateMenu()
    {
        int cursor = 0;
        foreach (TitleMenu menu in MenuTable)
        {
            if (Cursor == cursor)
            {
                menu.On();

                // �J�[�\���̈ʒu��ݒ�
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

