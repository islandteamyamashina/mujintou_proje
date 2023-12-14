using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    int Cursor = 0;                         // �J�[�\���ʒu
    public Option_menuBase[] OptionTable;   // �I�v�V�������ڂ��i�[
    public SpriteRenderer CursorRenderer;   // �J�[�\���p

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

        // �J�[�\���̐���
        if (Cursor < 0)
        {
            Cursor = OptionTable.Length - 1;
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
    }

    // ���j���[�̍X�V
    void SetMenu()
    {
        // �J�[�\���̈ʒu��ݒ�
        CursorRenderer.transform.position = OptionTable[Cursor].transform.position;

    }
}