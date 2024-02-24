using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    Text text;
    string str = "123456789‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ aaaaaaaaaaaaaaaaa";
    float interval = 0.1f;
    int strCount = 0;
    float time_sum = 0;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time_sum += Time.deltaTime;
        if(time_sum > interval)
        {
            time_sum = 0;
            strCount++;
        }
        text.text = str[..strCount];
    }
}
