using UnityEngine;

public class Cursol : MonoBehaviour
{
    [SerializeField] NewItem NewItem;
    private void Update()
    {
        //if (NewItem.isGetItem==true&&Input.GetMouseButtonDown(0))
        //{
        //    PlayerInfo.Instance.OnHover(0);


        //}
       /* else */if (NewItem.isGetItem==false&& Input.GetMouseButtonUp(0)) 
        {
            PlayerInfo.Instance.OnUnhover();
        }
        else if(NewItem.isGetItem==true&& Input.GetMouseButton(0)){
            PlayerInfo.Instance.OnHover(0);

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

