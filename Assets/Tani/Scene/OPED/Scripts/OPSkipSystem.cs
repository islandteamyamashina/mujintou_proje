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
    
    void Start()
    {
        
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
                    PlayerInfo.Instance.DoAction();
                    PlayerInfo.Instance.DoAction();
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
