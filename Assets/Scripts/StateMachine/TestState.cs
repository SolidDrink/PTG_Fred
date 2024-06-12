using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class TestState : MonoBehaviour
{
    public StateMachine stateMachine;
    public Transition[] transitions;
    public StateType stateType;
    public GameEventData[] onStateEnterEvents;
    public GameEventData[] onStateLeaveEvents;
    private List<UnityAction<string>> actionList = new List<UnityAction<string>>();
    private void Start()
    {
        
    }

    public virtual void OnStateEnter()
    {
        Debug.Log($"State {stateType}: OnStateEner");
        foreach (var transition in transitions)
        {
            actionList.Add((string param) =>
            {
                stateMachine.SwitchState(transition.nextStateType);
            });
            GameEventManager.Instance.RegisterEvent(transition.trasitionEvent, actionList[actionList.Count - 1]);
        }
        foreach (GameEventData eventData in onStateEnterEvents)
        {
            GameEventManager.Instance.SendEvent(eventData.gameEvent, eventData.parameter);
        }
    }

    public virtual void OnStateStay()
    {
        Debug.Log($"State { stateType}: OnStateStay");
    }

    public virtual void OnStateExit()
    {
        Debug.LogError($"State {stateType}: OnStateExit");
        for(int i = 0; i < transitions.Length; ++i)
        {
            GameEventManager.Instance.UnRegisterEvent(transitions[i].trasitionEvent, actionList[i]);
        }
        actionList.Clear();
        foreach (GameEventData eventData in onStateLeaveEvents)
        {
            GameEventManager.Instance.SendEvent(eventData.gameEvent, eventData.parameter);
        }
    }
}

[System.Serializable]
public class GameEventData 
{
    public GameEvent gameEvent;
    public string parameter;
}


[System.Serializable]
public class Transition
{
    public GameEvent trasitionEvent;
    public StateType nextStateType;
}