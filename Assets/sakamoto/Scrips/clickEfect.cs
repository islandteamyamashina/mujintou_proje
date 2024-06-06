using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEfect : MonoBehaviour
{
    //�N���b�N�G�t�F�N�g�̃v���n�u���擾
    [Header("�N���b�N�G�t�F�N�g�̃v���n�u������")]
    [SerializeField] GameObject efect;
    [Header("�N���b�N�G�t�F�N�g�̃v���n�u������")]
    [SerializeField] Animator animator;

    
    //�X�N���[�����W�ƃ��[���h���W�̐錾
    Vector3 mousePos, worldPos;
    // Start is called before the first frame update
    void Start()
    {
        //anime = efect.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {              
        //�}�E�X�̈ʒu���擾
        mousePos = Input.mousePosition;         
        //�}�E�X���W�����[���h���W�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y + 5, 10.0f));
        //Debug.Log(worldPos);
 
        if (Input.GetMouseButtonUp(0))
        {
            //if (efect)
            //{
            //    Destroy(efect);
            //}
            Debug.Log("���N���b�N"+ worldPos);

            //efect.transform.position = worldPos;
            //anime.SetBool("clickAnime", true);

            efect.SetActive(true);
            efect.transform.position = worldPos;
            animator.Play("clickAnime",0);
            //efect.transform.parent = parent.transform;

            //Debug.Log(efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position);
            //efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position = worldPos;
            //Debug.Log(efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position);

            //efect.transform.position = worldPos;
            //anime.SetBool("clickAnime", true);
            //Debug.Log(efect.transform.position);
        }

    }
}
