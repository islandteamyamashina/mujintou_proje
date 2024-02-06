using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusImage : MonoBehaviour
{
    [SerializeField] Image status_image;
    [SerializeField] Status_Type status_type = Status_Type.Health;
    [SerializeField] int init_mask_height = 100;
    RectTransform mask_rect_transform;
    RectTransform image_rect_transform;
    Vector2 init_mask_position;


    public enum Status_Type
    {
        Health,Hunger,Thirst
    }
    // Start is called before the first frame update
    void Start()
    {
        mask_rect_transform = GetComponent<RectTransform>();
        image_rect_transform = status_image.GetComponent<RectTransform>();
        init_mask_position = mask_rect_transform.anchoredPosition;

    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�^�X�Ɍ��t����mask��size��ύX
        mask_rect_transform.sizeDelta 
            = new Vector2(mask_rect_transform.rect.size.x, init_mask_height * PlayerInfo.Instance.GetStatusPercent((int)status_type));
        //mask�̉�������v����悤�Ɉړ�
        mask_rect_transform.anchoredPosition = new Vector2(init_mask_position.x,
           init_mask_position.y - (init_mask_height - mask_rect_transform.rect.size.y) / 2);
        //Image���K�؂ɍ����悤����
        image_rect_transform.anchoredPosition = new Vector2(0,
            (init_mask_height - mask_rect_transform.rect.size.y) / 2);
        if (Input.GetKeyDown(KeyCode.X)) { PlayerInfo.Instance.Health = 100; }
    }
}
