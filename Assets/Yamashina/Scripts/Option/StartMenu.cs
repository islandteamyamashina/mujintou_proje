using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : TitleMenu
{
    // 決定されたときの動作
   /* public override IEnumerator Select()
    {

        StartCoroutine(LoadScene());

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        // ロードがまだなら次のフレームへ
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
   */
}

