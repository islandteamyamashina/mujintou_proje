using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BadEndController : MonoBehaviour
{
    [SerializeField] Image backImage_Black;
    [SerializeField] GameObject textBox;
    [SerializeField] Fading fade;
    [SerializeField] GameObject SEAudio;
    [SerializeField] GameObject destroyObject;
    public void Bad()
    {
        StartCoroutine(BadEnd());
    }
    IEnumerator BadEnd()
    {
        var player = GameObject.FindAnyObjectByType<PlayerInfo>();
        GameObject playerOb = player.gameObject;
        playerOb.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        fade.fading_time = 3f;
        fade.Fade(Fading.type.FadeOut);
        fade.OnFadeEnd.AddListener(() =>
        { 

            textBox.gameObject.SetActive(false);
            backImage_Black.gameObject.SetActive(false);
            if(GameObject.FindGameObjectWithTag("SE")!=null)
            {
                SEAudio.GetComponent<anotherSoundPlayer>().ChooseSongs_SE(10);
            }
            fade.Fade(Fading.type.FadeIn);
            fade.OnFadeEnd.AddListener(() =>
            {
                
                if (PlayerInfo.InstanceNullable)
                {
                    PlayerInfo.Instance.DestroySelf();
                }

                DataManager.ErasePlayerSaveData();
            });
            
           
        });
        
        yield return null;
    }

}