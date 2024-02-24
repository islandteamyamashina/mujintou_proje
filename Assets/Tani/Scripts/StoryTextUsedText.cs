using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTextUsedText : TextControl
{
    [SerializeField] StoryTextData data;
    

    protected override void Start()
    {
        strs.Clear();
        foreach (var n in data.Texts)
        {
            Debug.Log(n);
            strs.Add(n);
        }
        base.Start();
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTextEnd()
    {
        //gameObject.SetActive(false);
    }
}
