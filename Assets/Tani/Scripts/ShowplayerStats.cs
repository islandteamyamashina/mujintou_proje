using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowplayerStats : MonoBehaviour
{

    Button button;
    Button.ButtonClickedEvent clickedEvent;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        clickedEvent = new Button.ButtonClickedEvent();
        clickedEvent.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Debug.Log($"Health: {PlayerInfo.Instance.Health},Hunger : {PlayerInfo.Instance.Hunger},Thirst : {PlayerInfo.Instance.Thirst}");
        PlayerInfo.Instance.Health -= 10;

        PlayerInfo.Instance.DoAction();
    }
}
