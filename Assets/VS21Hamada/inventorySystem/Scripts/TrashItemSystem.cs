using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItemSystem : MonoBehaviour
{
    //アイテムをすべて捨てる場合は16個になるため↓ここで指定。
    public NewItem[] TrashItems = new NewItem[16];
    private Collider2D AreaCollider;
    private SpriteRenderer srArea;
    [SerializeField] GameObject goTrashSet;
    private void Start()
    {
        srArea = GetComponent<SpriteRenderer>();
        AreaCollider = GetComponent<Collider2D>();
        DisableTrashArea();
    }
    public bool GetTrashAreaisShow()
    {
        if (srArea.enabled)
            return true;
        else
            return false;
    }
    public void DisableTrashArea()
    {
        goTrashSet.SetActive(false);
        srArea.enabled = false;
        AreaCollider.enabled = false;
    }
    public void EnableTrashArea()
    {
        goTrashSet.SetActive(true);
        srArea.enabled = true;
        AreaCollider.enabled = true;
    }
    public void OnTrashItem()
    {
        for (int i = 0; i < TrashItems.Length; i++)
        {
            if (TrashItems[i] == null) continue;

            TrashItems[i].TrashItem();
            TrashItems[i] = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            for (int i = 0; i < TrashItems.Length; i++)
            {
                if (TrashItems[i] == null)
                {
                    TrashItems[i] = collision.GetComponent<NewItem>();
                    break;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < TrashItems.Length; i++)
        {
            if (collision.gameObject == TrashItems[i].gameObject)
            {
                TrashItems[i] = null;
                break;
            }
        }
    }
}
