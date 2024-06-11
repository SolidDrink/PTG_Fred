using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    KeyCode targetKeyCode = KeyCode.None;
    public Condition(KeyCode keyCode)
    {
        targetKeyCode = keyCode;
    }
    public virtual bool IsQualified()
    {
        if(Input.GetKeyDown(targetKeyCode))
        {
            return true;
        }
        return false;
    }
}
