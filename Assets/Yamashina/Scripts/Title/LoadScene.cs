using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    [SerializeField] Fade fade;

    public void Start()
    {

        // fade.feadout_f = false;
    }
    // Update is called once per frame
    public void Text_of_each_places(int num = 0)
    {
        fade.scene_name_num = num;
        fade.feadout_f = true;
        //if (num == 0&& fade.feadout_f==false)
        //{
        //OnLoadSceneAdditive();

        //}
        //OnLoadSceneSingle();
    }
    //public void OnLoadSceneAdditive()
    //{
    //    //SceneB�����Z���[�h�B���݂̃V�[���͎c�����܂܂ŁA�V�[��B���ǉ������
    //    SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    //}
    //public void OnLoadSceneSingle()
    //{
    //    //SceneB�����[�h�B���݂̃V�[���͎����I�ɍ폜����āA�V�[��B�����ɂȂ�
    //    SceneManager.LoadScene("UIScene"); 
    //}


}

