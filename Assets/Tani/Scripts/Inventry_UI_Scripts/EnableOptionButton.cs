using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOptionButton : MonoBehaviour
{
    private void OnEnable()
    {
     
            gameObject.SetActive(!GameData.CanReturnTitle);
        
    }
}
