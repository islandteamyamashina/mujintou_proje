using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFire : MonoBehaviour
{
    [SerializeField]
    Image fire_icon_middle;
    [SerializeField]
    Button AddFireButton;
    [SerializeField]
    SlotManager SlotManager;

    private void OnEnable()
    {
        PlayerInfo.Instance.Inventry.SetVisible(true);
    }
    private void Awake()
    {
        
        AddFireButton.onClick.AddListener(() =>
        {
            PlayerInfo.Instance.Fire += 10;
            SlotManager.ChangeSlotItemAmount(SlotManager.GetSlotItem(0).Value.amount - 1,0);

        });
        PlayerInfo.Instance.Inventry.OnSlotVisibilityChanged += ApplySlotContollerVisibility;
    }

    private void FixedUpdate()
    {

        AddFireButton.interactable = SlotManager.GetSlotItem(0).Value.id == Items.Item_ID.item_mat_branch && PlayerInfo.Instance.Fire != 100;
        if (AddFireButton.interactable)
        {
            fire_icon_middle.fillAmount = Mathf.Clamp01((PlayerInfo.Instance.Fire + 10 )/ 100.0f);
        }
        else
        {
            fire_icon_middle.fillAmount = 0;
        }
        
    }
    void ApplySlotContollerVisibility()
    {
        if (!PlayerInfo.Instance.Inventry.GetVisibility())
        {
            ((BaseLocationDaytimeController)FindAnyObjectByType(
                 typeof(BaseLocationDaytimeController))).DeactivatePanel(1);
        }
    }

    private void OnDestroy()
    {
        if (PlayerInfo.InstanceNullable)
        {
            PlayerInfo.Instance.Inventry.OnSlotVisibilityChanged -= ApplySlotContollerVisibility;

        }
    }
}
