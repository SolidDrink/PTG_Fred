using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateB : State
{
    Condition condition = new Condition(KeyCode.C);
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.LogWarning("StateB Enter");
    }

    public override void Stay()
    {
        base.Stay();
        Debug.Log("StateB Stay");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.LogWarning("StateB Exit");
    }

    public override bool IsTransitionAvailable(out State nextState)
    {
        nextState = new StateC();
        return condition.IsQualified();
    }
}
