using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursol : MonoBehaviour
{
  
    public void OnmouseEnter()
    {
        Debug.Log("�J�[�\���ʂ���");
        PlayerInfo.Instance.OnHover(1);
        Debug.Log("�J�[�\���ʂ���");

    }

    public void OnmouseExit()
    {
        Debug.Log("�J�[�\���ʂ���");

        PlayerInfo.Instance.OnUnhover();
        Debug.Log("�J�[�\���ʂ���");

    }

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

