using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateC : State
{
    Condition condition = new Condition(KeyCode.A);
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.LogWarning("StateC Enter");
    }

    public override void Stay()
    {
        base.Stay();
        Debug.Log("StateC Stay");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.LogWarning("StateC Exit");
    }

    public override bool IsTransitionAvailable(out State nextState)
    {
        nextState = new StateA();
        return condition.IsQualified();
    }
}
