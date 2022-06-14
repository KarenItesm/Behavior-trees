using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_RepeaterInfinite : BT_Decorator
{
    public BT_RepeaterInfinite(BT_Node child) : base(child) { }

    public override void Tick()
    {
        if(child.CurrentState == BT_States.SUCCESS
            || child.CurrentState == BT_States.FAILURE)
        {
            child.Reset();
        }

        if(CurrentState == BT_States.IDLE)
        {
            CurrentState = BT_States.RUNNING;
        }
        child.Tick();
    }
}
