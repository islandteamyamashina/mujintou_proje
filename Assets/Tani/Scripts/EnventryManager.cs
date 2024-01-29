//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class EnventryManager : SingletonMonoBehaviour<EnventryManager>
//{

//    [SerializeField] private int _enventry_Height;
//    [SerializeField] private int _enventry_Widht;

//    [SerializeField]private List<Items> Item_Datas;
//    [SerializeField] private GameObject _Slot_Manager_Object;
//    private SlotManager _slot_manager;

//    [SerializeField] GameObject ItemViewObject;

//    protected override void Awake()
//    {
//        base.Awake();
//        DontDestroyOnLoad(this.gameObject);

//        _slot_manager = _Slot_Manager_Object.GetComponent<SlotManager>();
//    }
//    void Start()
//    {

//        if (Item_Datas.Count != (int)Items.Item_ID.Item_Max)
//        {
//            Debug.Log("アイテムデータに登録された個数が一致しません");
//        }


//       // ItemViewObject.GetComponent<ItemView>().SetViewItem(GetItemData(Items.Item_ID.Fish));
//    }

//    public Items GetItemData(Items.Item_ID id)
//    {
//        foreach(var n in Item_Datas)
//        {
//            if (n.item_ID == id) return n;
//        }

//        return null;
//    }

//    public void OnItemsChanged()
//    {
//        Debug.Log("EnventryManager OnItemsChanged");

//        _slot_manager.OnItemsChanged();
//    }

//    public void OnSlotSelected(int slotIndex)
//    {
//        Debug.Log($"slotindex : {slotIndex}");
//        ItemViewObject.GetComponent<ItemView>().SetViewItem(_slot_manager.GetSlots()[slotIndex].GetItem());
//    }
//}
