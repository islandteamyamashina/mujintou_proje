using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItem : MonoBehaviour
{
    public SO_Item ScriptalItem;
    public int CurrentStackCount;
    public bool isOverMouse, isGetItem;
    public Text txStack;

    // Update is called once per frame
    void Update()
    {
        CurrentStackCount = ScriptalItem.stackCount;
        txStack.text = CurrentStackCount.ToString();
        if (isGetItem)
        {
            gameObject.transform.position =
                new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }

        if (isOverMouse)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isGetItem = !isGetItem;
            }
        }
    }
    public void AddStack(int _Value)
    {
        CurrentStackCount += _Value;
    }
    public void MinStack(int _Value)
    {
        CurrentStackCount -= _Value;
    }
    private void OnMouseOver()
    {
        //isOverMouse = true;
    }
    private void OnMouseEnter()
    {
        isOverMouse = true;
    }
    private void OnMouseExit()
    {
        isOverMouse = false;
    }
}
