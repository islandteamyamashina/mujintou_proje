using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OPSkipSystem : MonoBehaviour
{
    [SerializeField]
    GameObject choise_buttons_parent;
    [SerializeField]
    Button cancel_button;

    [SerializeField]
    SceneObject baseLocation;
    
    void Start()
    {
        cancel_button.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });
        foreach (var button in choise_buttons_parent.GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(() =>
            {
                Items.Item_ID id = button.GetComponent<SpecialItemData>().specil_item_id;
                PlayerInfo.Instance.Inventry.GetItem(id, 1);
                SceneManager.LoadScene(baseLocation);
            });
        }
    }

    
    public void CreatSkipMenu()
    {

    }
}
