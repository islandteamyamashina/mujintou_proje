using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEfect : MonoBehaviour
{
    //クリックエフェクトのプレハブを取得
    [Header("クリックエフェクトのプレハブを入れて")]
    [SerializeField] GameObject efect;
    [Header("クリックエフェクトのプレハブを入れて")]
    [SerializeField] Animator animator;

    
    //スクリーン座標とワールド座標の宣言
    Vector3 mousePos, worldPos;
    // Start is called before the first frame update
    void Start()
    {
        //anime = efect.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {              
        //マウスの位置を取得
        mousePos = Input.mousePosition;         
        //マウス座標をワールド座標に変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y + 5, 10.0f));
        //Debug.Log(worldPos);
 
        if (Input.GetMouseButtonUp(0))
        {
            //if (efect)
            //{
            //    Destroy(efect);
            //}
            Debug.Log("左クリック"+ worldPos);

            //efect.transform.position = worldPos;
            //anime.SetBool("clickAnime", true);

            efect.SetActive(true);
            efect.transform.position = worldPos;
            animator.Play("clickAnime",0);
            //efect.transform.parent = parent.transform;

            //Debug.Log(efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position);
            //efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position = worldPos;
            //Debug.Log(efect.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.position);

            //efect.transform.position = worldPos;
            //anime.SetBool("clickAnime", true);
            //Debug.Log(efect.transform.position);
        }

    }
}
