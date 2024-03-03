using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cursol : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursor;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);

        }
    }
    public void OnPointerUp()
    {
        Destroy(gameObject);
    }
    public void OnPointerDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnMouseExit()
    {
        Debug.LogError("ÉJÅ[É\ÉãÇ™ó£ÇÍÇΩ");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnDrag()
    {
        Vector3 objectScreenPoint =
           new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(objectScreenPoint);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }
    
}

