using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prehubdelete : MonoBehaviour
{
    [SerializeField] public GameObject prefab;

    public void OnClick()
    {

        Destroy(prefab);


    }
}

