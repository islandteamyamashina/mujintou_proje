using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcedresolutiondesignation : MonoBehaviour

{ //���s�t�@�C���N�����ɃG�f�B�^�[�ŕ\�����Ă���UI�̈ʒu�����������Ȃ��聨����Unity���O�ɊJ�������̉�ʂ̉𑜓x���L�����Ă��ĕς��Ȃ����Ƃ�����B�ǂ����Ă����܂������Ȃ��ꍇ�̉𑜓x�̋����w��X�N���v�g

    public int ScreenWidth;
    public int ScreenHeight;

    void Awake()
    {
        // PC�����r���h��������T�C�Y�ύX
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(ScreenWidth, ScreenHeight, false);
        }
    }
}