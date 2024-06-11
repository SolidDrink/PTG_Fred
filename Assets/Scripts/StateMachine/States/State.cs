using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public State()
    { 
    }
    public virtual void OnStateEnter()
    {

    }

    public virtual void Stay()
    {

    }

    public virtual void OnStateExit()
    {

    }
    public virtual bool IsTransitionAvailable(out State nextState)
    {
        nextState = new State();
        return true;
    }
}
