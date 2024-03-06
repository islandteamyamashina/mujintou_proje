using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursol : MonoBehaviour
{
  
    public void OnmouseEnter()
    {
        Debug.Log("カーソル通った");
        PlayerInfo.Instance.OnHover(1);
        Debug.Log("カーソル通った");

    }

    public void OnmouseExit()
    {
        Debug.Log("カーソル通った");

        PlayerInfo.Instance.OnUnhover();
        Debug.Log("カーソル通った");

    }

    public void OnDrag()
    {
        Debug.Log("カーソル通った");

        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        TargetPos.z = 0;
        transform.position = TargetPos;
        Debug.Log("カーソル通った");

    }

}

