using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manage : MonoBehaviour
{
    [SerializeField] public EventData[] eventDatas;
    [SerializeField] public NewItem[] newItem;
    public int start_event_num;
    public int now_event_num;
    [SerializeField] int start_area;
    [SerializeField] Audiovolume audiovolume;
    [SerializeField] multiAudio multi;
    // Start is called before the first frame update
    void Awake()
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        multi.BGMSE();
        audiovolume.audioSourceBGM = GameObject.FindWithTag("BGM").GetComponent<AudioSource>();
        audiovolume.audioSourceSE = GameObject.FindWithTag("SE").GetComponent<AudioSource>();
       

        if (start_area == 0)
        {
            start_event_num = Random.Range(-1, 2) + 1;
            //Debug.Log("start_numは" + start_event_num + "です");
            if (start_event_num > 2)
            {
                start_event_num = 2;
            }
        }
        if (start_area == 1)
        {
            start_event_num = Random.Range(13, 16) + 1;
            //Debug.Log("start_numは" + start_event_num + "です");
            if (start_event_num > 16)
            {
                start_event_num = 16;
            }
        }
        now_event_num = start_event_num;
        now_event_num = 0;
        Debug.Log(eventDatas[start_event_num].Main_Text);

        if (audiovolume.audioClipsBGM != null)
        {
            Debug.Log(audiovolume.audioClipsBGM.Length);
        }
        else
        {
            Debug.Log("audioClipsBGM is Null!");
        }
        if (audiovolume.audioClipSE != null)
        {
            Debug.Log(audiovolume.audioClipSE.Length);
        }
        else
        {
            Debug.Log("audioClipSE is Null!");
        }
        if (audiovolume.audioClipsBGM != null)
        {
            //audiovolume.audioSourceBGM.clip = audiovolume.audioClipsBGM[1];
            //audiovolume.audioSourceBGM.Play();
        }
        else
        {

            Debug.Log("audioSourceBGM is Null!");
        }
        if (audiovolume.audioClipSE != null)
        {
            //audiovolume.audioSourceSE.clip = audiovolume.audioClipsBGM[1];
            //audiovolume.audioSourceSE.Play();
        }
        else
        {

            Debug.Log("audioSourceBGM is Null!");
        }
        Debug.Log("その他");

        multi.BgmLoadSlider();
        multi.SeLoadSlider();


    }

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }


}
