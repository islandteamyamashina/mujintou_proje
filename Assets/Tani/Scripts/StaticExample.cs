using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticExample :MonoBehaviour
{
    static public int staticInt = 1;
    static public int level = 1;
    static public int LevelUp()
    {
        level++;
        if(!(level <= 99)) { level = 99; }
        return level;
    }
    

}
