using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursol : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerInfo.Instance.OnHover(0);


        }
        else if (Input.GetMouseButtonUp(0))
        {
            PlayerInfo.Instance.OnUnhover();
        }
    }

    //public void OnmouseEnter()
    //{
    //    Debug.Log("�J�[�\���ʂ���");

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        PlayerInfo.Instance.OnHover(0);
    //    }
    //    else
    //        return;
    //        Debug.Log("�J�[�\���ʂ���");

    //}

    //public void OnmouseExit()
    //{
    //    Debug.Log("�J�[�\���ʂ���");

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        PlayerInfo.Instance.OnUnhover();
    //    }
    //    else return;
    //    Debug.Log("�J�[�\���ʂ���");

    //}

    public void OnDrag()
    {
        Debug.Log("�J�[�\���ʂ���");

        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        TargetPos.z = 0;
        transform.position = TargetPos;
        Debug.Log("�J�[�\���ʂ���");

    }

}

