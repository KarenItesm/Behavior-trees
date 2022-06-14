using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Succeeder : BT_Decorator
{
    public BT_Succeeder(BT_Node child) : base(child) { }

    public override void Tick()
    {
        if(child.CurrentState == BT_States.FAILURE || child.CurrentState == BT_States.SUCCESS)
        {
            CurrentState = BT_States.SUCCESS;
        }

        if(CurrentState == BT_States.IDLE)
        {
            CurrentState = BT_States.RUNNING;
        }

        child.Tick();
    }
}
