using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    Dictionary<StateType, TestState> states = new Dictionary<StateType, TestState>();
    TestState currentTestState = null;
    State currentState = null;
    public bool useTestState = false;
    void Start()
    {
        if (useTestState)
        {
            TestState[] States = GetComponentsInChildren<TestState>();
            foreach (TestState state in States)
            {
                states.Add(state.stateType, state);
                state.stateMachine = this;
            }
            SwitchState(StateType.A);
        }
        else
        {
            SwitchState(new StateA());
        }
    }
    private void Update()
    {
        if (!useTestState)
        {
            currentState.Stay();

            if(currentState.IsTransitionAvailable(out State nextState))
            {
                SwitchState(nextState);
            }
        }
    }
    public virtual void SwitchState(State newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    public virtual void SwitchState(StateType targetStateType)
    {
        if (useTestState)
        {
            if (states.TryGetValue(targetStateType, out TestState targetState))
            {
                currentTestState?.OnStateExit();
                currentTestState = targetState;
                currentTestState?.OnStateEnter();
            }
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



