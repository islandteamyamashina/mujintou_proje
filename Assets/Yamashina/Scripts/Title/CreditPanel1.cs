using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditPanel1 : MonoBehaviour
{
    //�p�l���֌W
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject OptionPanel;
    public GameObject QuitPanel;
    public GameObject startPanel;

    //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject CreditButton;
    [SerializeField] GameObject optionButton;

    //�{�^���̃C�x���g�g���K�[�֘A
    [SerializeField] EventTrigger eventTrigger_start;
    [SerializeField] EventTrigger eventTrigger_quit;
    [SerializeField] EventTrigger eventTrigger_Credit;
    [SerializeField] EventTrigger eventTrigger_option;
    //[SerializeField] EventTrigger eventTrigger_Continue_;

    //�{�^���@�\�֘A�iInteractive)
    public Button start;

    //public Button Continue;
    public Button quit;
    public Button Credit;
    public Button option;

    void Start()//�n�܂�Ƃ�
    {
        //�p�l���֌W
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        CreditButton.SetActive(true);

        //�V���O���g��
        PlayerInfo.Instance.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //�{�^���̃C�x���g�g���K�[�֘A
        eventTrigger_start.enabled = true;
        eventTrigger_quit.enabled = true;
        eventTrigger_option.enabled = true;
        eventTrigger_Credit.enabled = true;

        //�{�^���@�\�֘A�iInteractive)
        start.interactable = true;  
        quit.interactable = true;   
        Credit.interactable = true; 
        option.interactable = true; 
        //eventTrigger_Continue_.enabled = true;

    }

    public virtual void MainView()//���C����ʂ̂ݕ\��
    {
        if (startPanel.activeSelf)
        {
            StartSlideOut();
            startPanel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            startPanel.SetActive(false);

        }
        if (subPanel.activeSelf)
        {
            StartSlideOut();
            subPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            subPanel.SetActive(false);
            
        }
        if (OptionPanel.activeSelf)
        {
            StartSlideOut();
            OptionPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            OptionPanel.SetActive(false);

        }
        if (QuitPanel.activeSelf)
        {
            StartSlideOut();
            QuitPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
            QuitPanel.SetActive(false);

        }
        //�p�l���֌W
        mainPanel.SetActive(true);
        
        
       

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);
        CreditButton.SetActive(true);
       
        //�{�^���̃C�x���g�g���K�[�֘A
        eventTrigger_start.enabled = true;
        eventTrigger_quit.enabled = true;
        eventTrigger_option.enabled = true;
        eventTrigger_Credit.enabled = true;

        //�{�^���@�\�֘A�iInteractive)
        start.interactable = true;
        quit.interactable = true;
        Credit.interactable = true;
        option.interactable = true;
        
        
    }

    public virtual void SubView() //�N���W�b�g��ʕ\��
    {
        //�p�l���֌W
        mainPanel.SetActive(true);
        subPanel.SetActive(true);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(true);

        //�{�^���̃C�x���g�g���K�[�֘A
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //�{�^���@�\�֘A�iInteractive)
        //start.interactable = false;
        //quit.interactable = false;
        Credit.interactable = false;
        //option.interactable = false;

        //�p�l���g�傷��O�i�I�v�V�����p�l���j
        if (subPanel.activeSelf)
        {
            subPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }

    public virtual void CreditView()//�I�v�V�����\��
    {
        //�p�l���֌W
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(true);
        QuitPanel.SetActive(false);
        startPanel.SetActive(false);

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(true);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

        //�{�^���̃C�x���g�g���K�[�֘A
        //eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //�{�^���@�\�֘A�iInteractive)
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //quit.interactable = false;
        option.interactable = false;

        //�p�l���g�傷��O�i�I�v�V�����p�l���j
        if (OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }

    public void QuitView()//�I����ʕ\��
    {
        //�p�l���֌W
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(true);
        startPanel.SetActive(false);

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(false);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(true);
        CreditButton.SetActive(false);

        //�{�^���̃C�x���g�g���K�[�֘A
        //eventTrigger_start.enabled = false;
        eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //�{�^���@�\�֘A�iInteractive)
        //start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        quit.interactable = false;
        //option.interactable = false;

        //�p�l���g�傷��O�i�I���p�l���j
        if (QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartSlidein();
        }
    }
    public void startView()//�X�^�[�g�p�l���\��
    {
        //�p�l���֌W
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuitPanel.SetActive(false);
        startPanel.SetActive(true);

        //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
        startButton.SetActive(true);
        ContinueButton.SetActive(false);
        optionButton.SetActive(false);
        quitButton.SetActive(false);
        CreditButton.SetActive(false);

        //�{�^���̃C�x���g�g���K�[�֘A
        eventTrigger_start.enabled = false;
        //eventTrigger_quit.enabled = false;
        //eventTrigger_option.enabled = false;
        //eventTrigger_Credit.enabled = false;
        //eventTrigger_Continue_.enabled = false;

        //�{�^���@�\�֘A�iInteractive)
        start.interactable = false;
        //Continue.interactable = false;
        //Credit.interactable = false;
        //option.interactable = false;
        //quit.interactable = false;

        //�p�l���g�傷��O�i�X�^�[�g�p�l���j
        if (startPanel.activeSelf)
        {
            startPanel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            StartSlidein();
        }
    }
    
    public void StartSlidein()//�p�l���g��J�n�̂��߂̊֐�
    {
        StartCoroutine(ChangePaneltoBigSize());
    }

    //�p�l���g��(�ėp)
    public IEnumerator ChangePaneltoBigSize()
    {
        var size = 0f;
        var speed = 0.05f;
        var size2 = 0f;
        var size3 = 0f;
        var size4 = 0f;


        //�p�l���g��i�X�^�[�g�p�l���j

        while (size <= 1.0f && startPanel.activeSelf)
        {
            startPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.5f, 1.5f, 1.5f), size);
            size += speed;

            yield return null;
        }
        //�p�l���g��i�I�v�V�����p�l���j
        while (size2 <= 1.0f && OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size2);
            size2 += speed;

            yield return null;
        }
        //�p�l���g��i�N���W�b�g�p�l���j

        while (size3 <= 1.0f && subPanel.activeSelf)
        {
            subPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size3);
            size3 += speed;

            yield return null;
        }

        //�p�l���g��i�I���p�l���j

        while (size4 <= 1.0f && QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f), size4);
            size4 += speed;

            yield return null;
        }

    }

    public void StartSlideOut()//�p�l���k���J�n�̂��߂̊֐�
    {
        StartCoroutine(ChangePaneltoSmallSize());
    }

    //�p�l���k��(�ėp)
    public IEnumerator ChangePaneltoSmallSize()
    {
        var size = 0f;
        var speed = 0.05f;
        var size2 = 0f;
        var size3 = 0f;
        var size4 = 0f;


        //�p�l���k���i�X�^�[�g�p�l���j

        while (size <= 1.0f && startPanel.activeSelf)
        {
            startPanel.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), new Vector3(1.0f, 1.0f, 1.0f), size);
            size -= speed;

            yield return null;
        }
        //�p�l���k���i�I�v�V�����p�l���j
        while (size2 <= 1.0f && OptionPanel.activeSelf)
        {
            OptionPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size2);
            size2 -= speed;

            yield return null;
        }
        //�p�l���k���i�N���W�b�g�p�l���j

        while (size3 <= 1.0f && subPanel.activeSelf)
        {
            subPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size3);
            size3 -= speed;

            yield return null;
        }

        //�p�l���g��i�I���p�l���j

        while (size4 <= 1.0f && QuitPanel.activeSelf)
        {
            QuitPanel.transform.localScale = Vector3.Lerp(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(0.5f, 0.5f, 0.5f), size4);
            size4 -= speed;

            yield return null;
        }

    }
    void Update()
    {
        //escape�L�[�Ή�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //�p�l���֌W
            OptionPanel.SetActive(false);
            mainPanel.SetActive(true);
            subPanel.SetActive(false);
            QuitPanel.SetActive(false);
            startPanel.SetActive(false);

            //�Q�[���I�u�W�F�N�g�̃{�^��(Setactive)
            startButton.SetActive(true);
            ContinueButton.SetActive(true);
            optionButton.SetActive(true);
            quitButton.SetActive(true);
            CreditButton.SetActive(true);

            //�{�^���@�\�֘A�iInteractive)
            start.interactable = true;
            //Continue.interactable = true;
            Credit.interactable = true;
            quit.interactable = true;
            option.interactable = true;
           
            //�{�^���̃C�x���g�g���K�[�֘A
            eventTrigger_start.enabled = true;
            eventTrigger_quit.enabled = true;
            eventTrigger_option.enabled = true;
            eventTrigger_Credit.enabled = true;
        }
    }
}

