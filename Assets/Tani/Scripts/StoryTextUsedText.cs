using UnityEngine;

public class StoryTextUsedText : TextControl
{

    
    [SerializeField] TextAsset textAsset;

    string load_text;
    string[] split_text;


    protected override void Start()
    {
        base.Start();

        if (!textAsset) return;
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
        base.OnTextEnd();
    }
}
