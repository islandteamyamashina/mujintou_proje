using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    
    [SerializeField] private int iSideSlideValue;

    //�y�X�|�[��������ItemSlot.cs�̃v���n�u�A��70��ނ���A�C�e���B(����1�����B�z��ɂ��Ď�ނ𑝂₵�Ă�)�z
    public GameObject prefab_Slot, prefab_Item;

//�y��ցI�Q�����z��I�����ł�6x4�̑傫���ɂ��Ă��z
    public InventorySlot[,] cpSlots = new InventorySlot[6, 4];

    void Start()
    {
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 4; i++)
            {
�@�@//�@�y��dfor��2�����z��̒��ɏ��Ԃ�ItemSlot.cs���X�|�[��������(���̎������Ɉʒu�����炵�Ă��)�A�i�[�z
                cpSlots[k, i] = Instantiate(prefab_Slot, gameObject.transform.position + (Vector3.right * i * iSideSlideValue) + (Vector3.down * k * iSideSlideValue), gameObject.transform.rotation).GetComponent<InventorySlot>();
                cpSlots[k, i].transform.localScale = Vector3.one * 0.8f;

�@�@�@//�yItemSlot.cs�ō���Ă������֐����Ăяo���āA���ꂼ��ɔԍ������Ă����z
                cpSlots[k, i].GetComponent<InventorySlot>().SetSlotNum(i, k);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
�@�@//�y�L�[�{�[�h�������Ƃ��Ɋ֐����Ăяo���z
            GetItem();
        }
    }

    public void GetItem()
    {
�@//�y�A�C�e�����X�|�[��������(var�͌^���ŁA���̊֐����̂ݎg���郍�[�J���ϐ��B(�ǂ�Ȍ^�ł���̓���邱�Ƃ��ł���))�z
        var _Item = Instantiate(prefab_Item);
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 4; i++)
            {
�@�@�@//�y��dfor�̒���ItemSlot.cs�̒���Gameobject�ϐ��uItem�v�ɃA�N�Z�X���āA���g���m�F����z
�@�@�@//�y���������Ă��Ȃ���΂����ɃX�|�[���������A�C�e�����Z�b�g����z
                if (cpSlots[k, i].item == null)
                {
                    cpSlots[k, i].item = _Item;
                    _Item.transform.position = cpSlots[k, i].transform.position;
                    return;
                }
            }
        }
    }
    public void ShowItem(int x, int y)
    {
        Debug.Log("SlotNum" + x + ":" + y + "=" + cpSlots[x, y].item.GetComponent<Item>().name);
    }
}
