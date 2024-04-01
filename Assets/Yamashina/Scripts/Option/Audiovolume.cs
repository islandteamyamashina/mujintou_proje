using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Audiovolume : MonoBehaviour
{


    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;
    private int BGMvalue = 5;
    private int SEValue = 5;
    [SerializeField] AudioSource AudioSource_BGM;
    [SerializeField] AudioSource AudioSource_SE;
    private bool isSoundEnabled_BGM = true; // �����Đ�����邩�ǂ������Ǘ�����t���O

    private void Start()
    {
        if (AudioSource_BGM == null)
        {
            // AudioSource_BGM���A�T�C������Ă��Ȃ��ꍇ�A���݂̃Q�[���I�u�W�F�N�g����AudioSource���������ăA�T�C������
            AudioSource_BGM = GameObject.Find("BGM_ob").GetComponent<AudioSource>();    


        }
        if (AudioSource_SE == null)
        {
            AudioSource_SE= GameObject.Find("SE_ob").GetComponent<AudioSource>();
        }
        bGMSlider.value = BGMvalue;
        sESlider.value = SEValue;
        audioMixer.GetFloat("BGM", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE", out float seVolume);
        sESlider.value = seVolume;

        // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��ɌĂяo�����C�x���g�n���h����ݒ�
        bGMSlider.onValueChanged.AddListener(OnBGMSliderValueChanged);
        sESlider.onValueChanged.AddListener(OnSESliderValueChanged);
    }

    void OnBGMSliderValueChanged(float value)
    {
        // �X���C�_�[�̒l�ɉ����ĉ��ʂ𒲐�
        // �����ł́A�X���C�_�[�̍ŏ��l��0�A�ő�l��1�Ɖ��肵�Ă��܂�
        AudioSource_BGM.volume = value;

        // �X���C�_�[����Ԓ[�ɍs�����ꍇ�A��������
        if (value == bGMSlider.minValue || value == bGMSlider.maxValue)
        {
            AudioSource_BGM.volume = 0f;
        }
       

    }
    void OnSESliderValueChanged(float value)
    {
        AudioSource_SE.volume = value;
        // �X���C�_�[����Ԓ[�ɍs�����ꍇ�A��������
        if (value == sESlider.minValue || value == sESlider.maxValue)
        {
            isSoundEnabled_BGM = false;       
        }
        else
        {
            isSoundEnabled_BGM = true;
        }
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
   
}

