using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    [SerializeField] GameObject o1;
    [SerializeField] GameObject o2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        Debug.Log("ï∂èÕÇÃèIÇÌÇË");
    }
    public void Make()
    {
        Instantiate(o2);
        o2.transform.SetParent(GameObject.Find("Canvas").transform);
        o2.transform.localPosition = Vector3.zero;
    }

}
