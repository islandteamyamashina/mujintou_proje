using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursol : MonoBehaviour,IDragHandler
{
    // Start is called before the first frame update
    


    public Texture2D handCursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(handCursor, new Vector2(handCursor.width / 2, handCursor.height / 2), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(eventData.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }
}

