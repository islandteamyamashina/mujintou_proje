using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePanel : PanelBase
{
    [SerializeField]
    List<GameObject> fire_panels;


    [SerializeField]
    GameObject main;
    [SerializeField]
    Button ToMakeFire;
    [SerializeField]
    Button ToAddFire;
    [SerializeField]
    Button ToCooking;
    [SerializeField]
    Image fire_icon_front;
    [SerializeField]
    Image fire_icon_middle;

    bool isFirst = true;

    protected override void Awake()
    {
        base.Awake();

        SetSortOrder(OrderOfUI.NormalPanel);
        SetFirePanelActivate(0);
        SetFirePanelActivate(1);
        SetFirePanelActivate(2);

        fire_icon_front.fillAmount = PlayerInfo.Instance.Fire / 100.0f;
        ToCooking.interactable = PlayerInfo.Instance.Fire != 0;

        PlayerInfo.Instance.Inventry.OnSlotVisibilityChanged += ApplySlotContollerVisibility;
    }
    protected override void Start()
    {




    }
    private void OnEnable()
    {
        SetFirePanelActivate(0);
        fire_icon_middle.fillAmount = 0;
        
    }
    protected�@override void Update()
    {
        base.Update();

        ToMakeFire.gameObject.SetActive(PlayerInfo.Instance.Fire == 0);
        ToAddFire.gameObject.SetActive(PlayerInfo.Instance.Fire != 0);
        fire_icon_front.fillAmount = PlayerInfo.Instance.Fire / 100.0f;
        ToCooking.interactable = PlayerInfo.Instance.Fire != 0;
    }

    public void SetFirePanelActivate(int index)
    {
        for (int i = 0; i < fire_panels.Count; i++)
        {
            fire_panels[i].SetActive(false);
        }
        if(index == 1)
        {
            if(!isFirst)
                fire_panels[1].GetComponent<MakeFire>().Init();
            isFirst = false;
        }
        fire_panels[index].SetActive(true);
    }

    void ApplySlotContollerVisibility()
    {
        if (!PlayerInfo.Instance.Inventry.GetVisibility())
        {
            ((BaseLocationDaytimeController)FindAnyObjectByType(
                 typeof(BaseLocationDaytimeController))).DeactivateAllPanels();
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
