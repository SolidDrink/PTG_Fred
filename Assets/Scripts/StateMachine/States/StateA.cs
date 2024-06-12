using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : State
{
    Condition condition = new Condition(KeyCode.B);
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.LogWarning("StateA Enter");
        GameEventManager.Instance.SendEvent(GameEvent.OnStateChange, "A");
    }

    public override void Stay()
    {
        base.Stay();
        Debug.Log("StateA Stay");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.LogWarning("StateA Exit");
    }

    public override bool IsTransitionAvailable(out State nextState)
    {
        nextState = new StateB();
        return condition.IsQualified();
    }
}
