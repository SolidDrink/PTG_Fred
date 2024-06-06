using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class StateBase : MonoBehaviour
{
    public StateMachineBase stateMachine;
    public TransitionBase[] transitions;
    public StateType stateType;
    public GameEvent[] onStateEnterEvents;
    public GameEvent[] onStateLeaveEvents;
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
        foreach (GameEvent gameEvent in onStateEnterEvents)
        {
            GameEventManager.Instance.SendEvent(gameEvent);
        }
    }

    public virtual void OnStateStay()
    {

    }

    public virtual void OnStateExit()
    {
        Debug.Log($"State {stateType}: OnStateExit");
        for(int i = 0; i < transitions.Length; ++i)
        {
            GameEventManager.Instance.UnRegisterEvent(transitions[i].trasitionEvent, actionList[i]);
        }
        actionList.Clear();
        foreach (GameEvent gameEvent in onStateLeaveEvents)
        {
            GameEventManager.Instance.SendEvent(gameEvent);
        }
    }
}
