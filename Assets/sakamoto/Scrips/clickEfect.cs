using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEfect : MonoBehaviour
{
    [SerializeField] GameObject efect;
    Vector3 mousePos, worldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {              
        //�}�E�X�̈ʒu���擾
        mousePos = Input.mousePosition;         
        //�}�E�X���W�����[���h���W�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
        //Debug.Log(worldPos);
 
        if (Input.GetMouseButtonDown(0))
        {
            //if(efect)
            //{
            //    Destroy(efect);
            //}
            Debug.Log("���N���b�N");  
            Instantiate(efect,worldPos,Quaternion.Euler(0.0f,0.0f,0.0f));          
            //Debug.Log(efect.transform.position);
        }   
        



    }
}
