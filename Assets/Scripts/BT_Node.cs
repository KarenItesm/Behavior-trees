using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BT_States
{
    IDLE,
    SUCCESS,
    FAILURE,
    RUNNING
}

public abstract class BT_Node
{
    public BT_States CurrentState
    {
        get;
        set;
    }

    public BT_Node()
    {
        CurrentState = BT_States.IDLE;
    }

    public abstract void Tick();
    public abstract void Reset();
}

