using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_menu : TitleMenu
{
    // Start is called before the first frame update
   
     public GameObject Option;
    GameObject clone;

    // 決定されたときの動作
    public override IEnumerator Select()
    {
        
    
        // 試しに２秒待つ
        yield return new WaitForSeconds(2.0f);
    clone = Instantiate(Option);
        // オプションが消えるまでループ
        while (clone)
        {
            yield return null;
        }
    }

}

