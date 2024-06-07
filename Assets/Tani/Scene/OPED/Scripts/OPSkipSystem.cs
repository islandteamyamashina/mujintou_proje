using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OPSkipSystem : MonoBehaviour
{
    [SerializeField]
    GameObject Skip_display_prefab;


    [SerializeField]
    SceneObject baseLocation;
    [SerializeField]
    Button SkipButton;
    
    void Start()
    {

    }
    public void DestroySkipButton()
    {
        if (SkipButton)
        {
            Destroy(SkipButton.gameObject);
        }
    }

    
    public void CreatSkipMenu()
    {
        var go =  Instantiate<GameObject>(Skip_display_prefab);
        foreach (var button in go.GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(() =>
            {
                var data = button.gameObject.GetComponent<SpecialItemData>();
                if (data)
                {
                    PlayerInfo.Instance.Inventry.GetItem(data.specil_item_id, 1);
                    PlayerInfo.Instance.FirstItemId = (int)data.specil_item_id;
                    PlayerInfo.Instance.DoAction();
                    PlayerInfo.Instance.DoAction();
                    PlayerInfo.Instance.Inventry.UseItem(Items.Item_ID.item_craft_coconutJuice);
                    PlayerInfo.Instance.Inventry.GetItem(Items.Item_ID.item_mat_bottle, 1);

                    PlayerInfo.Instance.Health = 100;
                    PlayerInfo.Instance.Thirst = 83;
                    PlayerInfo.Instance.Hunger = 75;
                    SceneManager.LoadScene(baseLocation);
                }
                else
                {
                    Destroy(go);

                }

            });
        }
    }
}
