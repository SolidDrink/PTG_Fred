using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBase : MonoBehaviour
{
    Dictionary<StateType, StateBase> states = new Dictionary<StateType, StateBase>();
    StateBase currentState = null;
    void Start()
    {
        StateBase[] stateBases = GetComponentsInChildren<StateBase>();
        foreach (StateBase state in stateBases)
        {
            states.Add(state.stateType, state);
            state.stateMachine = this;
        }

        SwitchState(StateType.A);
    }

    public virtual void SwitchState(StateType targetStateType)
    {
        if (states.TryGetValue(targetStateType, out StateBase targetState))
        {
            currentState?.OnStateExit();
            currentState = targetState;
            currentState?.OnStateEnter();
        }
    }
}

public enum StateType
{
    None = 0,
    A,
    B,
    C,
}

[System.Serializable]
public class TransitionBase
{
    public GameEvent trasitionEvent;
    public StateType nextStateType;
}

