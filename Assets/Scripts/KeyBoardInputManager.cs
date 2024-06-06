using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInputManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameEventManager.Instance.SendEvent(GameEvent.On_Button_A_Pressed);
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            GameEventManager.Instance.SendEvent(GameEvent.ON_Button_B_Pressed);
        }

        else if(Input.GetKeyDown(KeyCode.C))
        {
            GameEventManager.Instance.SendEvent(GameEvent.ON_Button_C_Pressed);
        }
    }
}
