using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeFire : MonoBehaviour
{
    [SerializeField]
    SlotManager slotManager;

    [Space(20)]
    [SerializeField]
    Button select_hand;
    [SerializeField]
    int health_Change_Hand = 10;
    [SerializeField]
    int hunger_Change_Hand = 10;
    [SerializeField]
    int thirst_Change_Hand = 10;

    [Space(20)]
    [SerializeField]
    Button select_FireSet;
    [SerializeField]
    int health_Change_FireSet = 10;
    [SerializeField]
    int hunger_Change_FireSet = 10;
    [SerializeField]
    int thirst_Change_FireSet = 10;

    [Space(20)]
    [SerializeField]
    Button select_Lighter;
    [SerializeField]
    int health_Change_Lighter = 10;
    [SerializeField]
    int hunger_Change_Lighter = 10;
    [SerializeField]
    int thirst_Change_Lighter = 10;

    [SerializeField]
    Text SelectedResultText;
    [SerializeField]
    Text health_Change_Text;
    [SerializeField]
    Text thirst_Change_Text;
    [SerializeField]
    Text hunger_Change_Text;
    [SerializeField]
    Button MakeFireButton;
    [SerializeField]
    Image Fire_Icon_Middle;
    [SerializeField]
    Image trans1;
    [SerializeField]
    Image trans2;
    [SerializeField]
    Text success_posibility_text;
    [SerializeField]
    Button closeThisPanelButton;

    int selectedType = 0;//0 : なし 1 : 素手 ,2 : FireSet ,3 : Lighter


    
    private void OnEnable()
    {
        selectedType = 0;
        Fire_Icon_Middle.fillAmount = 0;
        SelectedResultText.text = "";
        var info = PlayerInfo.Instance;
        health_Change_Text.text = $"{info.Health} >> {info.Health}";
        hunger_Change_Text.text = $"{info.Hunger} >> {info.Hunger}";
        thirst_Change_Text.text = $"{info.Thirst} >> {info.Thirst}";
        success_posibility_text.text = "";

        PlayerInfo.Instance.Inventry.SetVisible(true);
  

    }

    public void Init()
    {
        select_FireSet.interactable = slotManager.GetSlotItem(0).Value.id == Items.Item_ID.item_craft_onFireSet;
        select_Lighter.interactable = slotManager.GetSlotItem(1).Value.id == Items.Item_ID.item_special_lighter;
        MakeFireButton.interactable = selectedType switch
        {
            0 => false,

            1 => PlayerInfo.Instance.Health >= -health_Change_Hand &&
                             (PlayerInfo.Instance.Hunger >= -hunger_Change_Hand &&
                             PlayerInfo.Instance.Thirst >= -thirst_Change_Hand),

            2 => (slotManager.GetSlotItem(0).Value.id == Items.Item_ID.item_craft_onFireSet &&
                            PlayerInfo.Instance.Health >= -health_Change_FireSet) &&
                            (PlayerInfo.Instance.Hunger >= -hunger_Change_FireSet &&
                            PlayerInfo.Instance.Thirst >= -thirst_Change_FireSet),

            3 => (slotManager.GetSlotItem(1).Value.id == Items.Item_ID.item_special_lighter &&
                             PlayerInfo.Instance.Health >= -health_Change_Lighter) &&
                             (PlayerInfo.Instance.Hunger >= -hunger_Change_Lighter &&
                             PlayerInfo.Instance.Thirst >= -thirst_Change_Lighter),
            _ => false
        };
    }

    private void Update()
    {

        select_FireSet.interactable = slotManager.GetSlotItem(0).Value.id == Items.Item_ID.item_craft_onFireSet;
        select_Lighter.interactable = slotManager.GetSlotItem(1).Value.id == Items.Item_ID.item_special_lighter;

        MakeFireButton.interactable = selectedType switch
        {
           0=>false,

           1 =>              PlayerInfo.Instance.Health >= -health_Change_Hand &&
                            (PlayerInfo.Instance.Hunger >= -hunger_Change_Hand &&
                            PlayerInfo.Instance.Thirst >= -thirst_Change_Hand),

            2 => (slotManager.GetSlotItem(0).Value.id == Items.Item_ID.item_craft_onFireSet &&
                            PlayerInfo.Instance.Health >= -health_Change_FireSet)&&
                            (PlayerInfo.Instance.Hunger >= -hunger_Change_FireSet &&
                            PlayerInfo.Instance.Thirst >= -thirst_Change_FireSet),

           3=> (slotManager.GetSlotItem(1).Value.id == Items.Item_ID.item_special_lighter &&
                            PlayerInfo.Instance.Health >= -health_Change_Lighter) &&
                            (PlayerInfo.Instance.Hunger >= -hunger_Change_Lighter &&
                            PlayerInfo.Instance.Thirst >= -thirst_Change_Lighter),
            _=> false
        };
        MakeFireButton.interactable = PlayerInfo.Instance.Fire == 0 && selectedType != 0;
        if(PlayerInfo.Instance.Hunger == 0 || PlayerInfo.Instance.Thirst == 0)
        {
            MakeFireButton.interactable = false;
        }
        if(slotManager.GetSlotItem(0).Value.id != Items.Item_ID.EmptyObject)
        {
            var color = trans1.color;
            color.a = 0;
            trans1.color = color;
        }
        else
        {
            var color = trans1.color;
            color.a = 0.8f;
            trans1.color = color;
        }

        if (slotManager.GetSlotItem(1).Value.id != Items.Item_ID.EmptyObject)
        {
            var color = trans2.color;
            color.a = 0;
            trans2.color = color;
        }
        else
        {
            var color = trans2.color;
            color.a = 0.8f;
            trans2.color = color;
        }


    }

    private void Awake()
    {
        PlayerInfo.Instance.Inventry.OnSlotVisibilityChanged += ApplySlotContollerVisibility;


        closeThisPanelButton.onClick.AddListener(()=>{
            ((FirePanel)FindAnyObjectByType(typeof(FirePanel))).SetFirePanelActivate(0);
            Fire_Icon_Middle.fillAmount = 0;
        });

        select_hand.onClick.AddListener(() =>
        {
            var info = PlayerInfo.Instance;
            selectedType = 1;
            health_Change_Text.text = $"{info.Health} >> {Mathf.Clamp(info.Health + health_Change_Hand, 0, 100)}";
            hunger_Change_Text.text = $"{info.Hunger} >> {Mathf.Clamp(info.Hunger + hunger_Change_Hand, 0, 100)}";
            thirst_Change_Text.text = $"{info.Thirst} >> {Mathf.Clamp(info.Thirst + thirst_Change_Hand, 0, 100)}";
            SelectedResultText.text = "素手でやるしかない";
            Fire_Icon_Middle.fillAmount = 0.3f;
            success_posibility_text.text = "成功確率 : 30%";
        });

        select_FireSet.onClick.AddListener(() =>
        {
            var info = PlayerInfo.Instance;
            selectedType = 2;
            health_Change_Text.text = $"{info.Health} >> {Mathf.Clamp(info.Health + health_Change_FireSet, 0, 100)}";
            hunger_Change_Text.text = $"{info.Hunger} >> {Mathf.Clamp(info.Hunger + hunger_Change_FireSet, 0, 100)}";
            thirst_Change_Text.text = $"{info.Thirst} >> {Mathf.Clamp(info.Thirst + thirst_Change_FireSet, 0, 100)}";
            SelectedResultText.text = "火おこしセットを使用";
            Fire_Icon_Middle.fillAmount = 0.3f;
            success_posibility_text.text = "成功確率 : 80%";
        });

        select_Lighter.onClick.AddListener(() =>
        {
            var info = PlayerInfo.Instance;
            selectedType = 3;
            health_Change_Text.text = $"{info.Health} >> {Mathf.Clamp(info.Health + health_Change_Lighter, 0, 100)}";
            hunger_Change_Text.text = $"{info.Hunger} >> {Mathf.Clamp(info.Hunger + hunger_Change_Lighter, 0, 100)}";
            thirst_Change_Text.text = $"{info.Thirst} >> {Mathf.Clamp(info.Thirst + thirst_Change_Lighter, 0, 100)}";
            SelectedResultText.text = "ライターを使う";
            Fire_Icon_Middle.fillAmount = 0.3f;
            success_posibility_text.text = "成功確率 : 100%";
        });

        MakeFireButton.onClick.AddListener(() =>
        {
            PlayerInfo.Instance.Health += selectedType switch
            {
                1 => health_Change_Hand,
                2 => health_Change_FireSet,
                3 => health_Change_Lighter,
                _ => 0
            };

            PlayerInfo.Instance.Hunger += selectedType switch
            {
                1 => hunger_Change_Hand,
                2 => hunger_Change_FireSet,
                3 => hunger_Change_Lighter,
                _ => 0
            };

            PlayerInfo.Instance.Thirst += selectedType switch
            {
                1 => thirst_Change_Hand,
                2 => thirst_Change_FireSet,
                3 => thirst_Change_Lighter,
                _ => 0
            };
            if( selectedType == 2)
            {
                slotManager.ChangeSlotItemAmount(slotManager.GetSlotItem(0).Value.amount - 1, 0);

            }

            float random = Random.value;
            if(random <= selectedType switch
            {
                1=> 0.3f,
                2=>0.8f,
                3=>1f,
                _=>0
            })
            {
                PlayerInfo.Instance.Fire += 30;
                Fire_Icon_Middle.fillAmount = 0;
                SelectedResultText.text = "火おこし成功!";
                ((anotherBGMPlayer)FindAnyObjectByType(typeof(anotherBGMPlayer))).ChangeBGM(1);
            }
            else
            {
                var info = PlayerInfo.Instance;
                health_Change_Text.text = $"{info.Health} >> {info.Health}";
                hunger_Change_Text.text = $"{info.Hunger} >> {info.Hunger}";
                thirst_Change_Text.text = $"{info.Thirst} >> {info.Thirst}";
                SelectedResultText.text = "火おこし失敗!";
                selectedType = 0;
                success_posibility_text.text = "";
            }

        });
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
