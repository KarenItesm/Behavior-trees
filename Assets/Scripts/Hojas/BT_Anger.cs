using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Anger : BT_Node
{
    private AngerBehaviour behaviour;

    //constructor
    public BT_Anger(AngerBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public override void Tick()
    {
        Debug.Log($"Tick en BT Anger {CurrentState}");
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
