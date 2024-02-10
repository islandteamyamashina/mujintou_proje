using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class effect : MonoBehaviour
{
    [SerializeField] GameObject effectPanal;
    Color color;
    public bool damage_f;

    // Start is called before the first frame update
    void Start()
    {
        damage_f = false;
        effectPanal.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        effectPanal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(damage_f) 
        {
            Damage();
        }
    }

    void Damage()
    {
        effectPanal.SetActive(true);
        if ((0 < color.a))
        {
            color.a -= 0.0015f;
            effectPanal.GetComponent<Image>().color = color;
        }
        if (color.a <= 0)
        {
            effectPanal.SetActive(false);
            damage_f = false;
            color.a = 0.0015f;
            effectPanal.GetComponent<Image>().color = color;

        }

    }
}
