using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitletoOption : MonoBehaviour
{
    [SerializeField] public GameObject prefab;

    public void OnClick()
    {

        Instantiate(prefab);


    }
}
