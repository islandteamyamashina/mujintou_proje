using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
   //�y�������A�C�e���X���b�g�̉��ԖڂȂ̂��H�� x, y (�֐��ŏ��������܂�)�z
    private int x, y;

//�y�����̃X���b�g���ɂ���A�C�e����ۊǂ���ϐ��z
    public GameObject item;

//�y�}�l�[�W���[���擾(�����static GameManager���ŃC���X�^���X�������Ă��u���Ƃ���Ɂ�)�z
  //  private InventoryManager cpInventoryManager;

    void Start()
    {
       // �y���������I�ɐ��������̂ŁA�X�|�[��������Ƀ}�l�[�W���[��T���z
       // cpInventoryManager = GameObject.Find("StorageManage").GetComponent<InventoryManager>();
    }

//�y�}�l�[�W���[���ŌĂяo���֐��B���g�̔z��Ԓn���}�l�[�W���[���狳���Ă��炤�z
    public void SetSlotNum(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

//�y�}�l�[�W���[���ŌĂяo���֐��B�����ł�����Ă����A�C�e���������̃X���b�g�̏ꏊ�Ɉړ�������z
    public void SetItem(GameObject _Itemvalue)
    {
        _Itemvalue.transform.position = transform.position;
    }
}
