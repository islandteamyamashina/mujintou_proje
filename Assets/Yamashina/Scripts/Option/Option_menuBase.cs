using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_menuBase : MonoBehaviour
{
    // 左入力の動作
    public virtual void Left() { }

    // 右入力の動作
    public virtual void Right() { }

    // 決定の動作
    public virtual void Select() { }
}

