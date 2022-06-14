using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Inverter : BT_Decorator
{
    public BT_Inverter(BT_Node child) : base(child) { }
    public override void Tick()
    {
        if(child.CurrentState == BT_States.FAILURE)
        {
            CurrentState = BT_States.SUCCESS;
            return;
        }

        if (child.CurrentState == BT_States.SUCCESS)
        {
            CurrentState = BT_States.FAILURE;
        }

        if (CurrentState == BT_States.IDLE)
        {
            CurrentState = BT_States.RUNNING;
            return;
        }

        child.Tick();
    }
}
