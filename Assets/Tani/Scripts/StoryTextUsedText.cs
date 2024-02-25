using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class StoryTextUsedText : TextControl
{
    [SerializeField] UnityEvent EndEvent;

    
    [SerializeField] TextAsset textAsset;

    string load_text;
    string[] split_text;

    protected override void Start()
    {
        base.Start();
        load_text = textAsset.text;
        split_text = load_text.Split(char.Parse("\n"));
        foreach(var n in split_text)
        {
            if (n == "") continue;
            strs.Add(n);
        }

        
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTextEnd()
    {
        EndEvent.Invoke();
    }
}
