using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Acceptance : BT_Node
{
    private AcceptanceBehaviour behaviour;

    //constructor
    public BT_Acceptance(AcceptanceBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public override void Tick()
    {
        Debug.Log($"Tick en BT Acceptance {CurrentState}");
        if (CurrentState == BT_States.IDLE)
        {
            behaviour.enabled = true;
            CurrentState = BT_States.RUNNING;
            return;
        }

        if (CurrentState == BT_States.RUNNING)
        {
            if (behaviour.isDone)
            {
                behaviour.enabled = false;
                CurrentState = BT_States.SUCCESS;
                return;
            }
        }
    }

    public override void Reset()
    {
        CurrentState = BT_States.IDLE;
        behaviour.isDone = false;
    }
}
