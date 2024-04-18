using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaNameText : MonoBehaviour
{
    //[SerializeField]
    //string areaName;
    [SerializeField]
    Text text;

    float inTime = 0.75f;
    float outTime = 0.75f;
    float stayTime = 1f;

    public IEnumerator  ShowAreaText()
    {
        text.text = PlayerInfo.Instance.Day.isDayTime ? "‹’“_(’‹)" : "‹’“_(–é)";
        Rect canvas_size = text.canvas.pixelRect;
        Vector3 startPos = new Vector3(canvas_size.width, canvas_size.height / 2);
        Vector3 stayPos = new Vector3(canvas_size.width / 2, canvas_size.height / 2);
        Vector3 endPos = new Vector3(0, canvas_size.height / 2);

        float time = 0;
        text.gameObject.SetActive(true);
        while (true)
        {
            time += Time.deltaTime;
            text.gameObject.transform.position = Vector3.Lerp(startPos, stayPos, time / inTime);
            if (time >= inTime) break;
            yield return null;
        }
        time = 0;
        while (true)
        {
            time += Time.deltaTime;
            if (time >= stayTime) break;
            yield return null;
        }
        time = 0;
        while (true)
        {
            time += Time.deltaTime;
            text.gameObject.transform.position = Vector3.Lerp(stayPos, endPos, time / outTime);
            if (time >= outTime) break;
            yield return null;
        }
        Destroy(text.gameObject);

    }

}
