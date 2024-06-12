using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StateText : MonoBehaviour
{
    TMP_Text text;
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        GameEventManager.Instance.RegisterEvent(GameEvent.OnStateChange, OnStateChange);
        GameEventManager.Instance.RegisterEvent(GameEvent.OnTestStateChange, OnTestStateChange);
    }

    private void OnStateChange(string param)
    {
        text.text = $"Current State: " + param;
    }

    private void OnTestStateChange(string param)
    {
        text.text = $"Current TestState: " + param;
    }
}
