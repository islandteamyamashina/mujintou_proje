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
        //ステータスに元付いてmaskのsizeを変更
        mask_rect_transform.sizeDelta 
            = new Vector2(mask_rect_transform.rect.size.x, init_mask_height * PlayerInfo.Instance.GetStatusPercent((int)status_type));
        //maskの下部が一致するように移動
        mask_rect_transform.anchoredPosition = new Vector2(init_mask_position.x,
           init_mask_position.y - (init_mask_height - mask_rect_transform.rect.size.y) / 2);
        //Imageが適切に削られるよう調整
        image_rect_transform.anchoredPosition = new Vector2(0,
            (init_mask_height - mask_rect_transform.rect.size.y) / 2);
        if (Input.GetKeyDown(KeyCode.X)) { PlayerInfo.Instance.Health = 100; }
    }
}
