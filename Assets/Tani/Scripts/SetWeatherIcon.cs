using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWeatherIcon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = PlayerInfo.Instance.SunnyCloudyRainy[(int)PlayerInfo.Instance.weather];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
