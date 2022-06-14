using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_RepFailure : BT_Decorator
{
    public BT_RepFailure(BT_Node child) : base(child) { }

    public override void Tick()
    {
        if(CurrentState == BT_States.SUCCESS)
        {
            return;
        }

        if (child.CurrentState == BT_States.FAILURE)
        {
            CurrentState = BT_States.SUCCESS;
        }

        if (child.CurrentState == BT_States.SUCCESS)
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
