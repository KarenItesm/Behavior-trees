using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_CheckAcceptance : BT_Node
{
 //checate si el behavior que debería venir aqui no es mas bien lo que quieres qeu corra?
    private AcceptanceBehaviour behaviour;
    private int acceptanceThreshold;

    public BT_CheckAcceptance(AcceptanceBehaviour behaviour,int acceptanceThreshold)
    {
        this.behaviour = behaviour;
        this.acceptanceThreshold = acceptanceThreshold;
    }

    public override void Tick()
    {
        Debug.Log($"Tick en BT CheckAcceptance {CurrentState}, Level: {behaviour.acceptanceLevel}");

        if (CurrentState == BT_States.IDLE)
        {
            //behaviour.enabled = true;
            CurrentState = BT_States.RUNNING;
        }

        behaviour.DistanceCheck();


        if (CurrentState == BT_States.RUNNING)
        {
            if (behaviour.acceptanceLevel >= acceptanceThreshold)
            {
                //behaviour.enabled = false;
                CurrentState = BT_States.SUCCESS;
            }
        }
    }

    public override void Reset()
    {
        CurrentState = BT_States.IDLE;
        behaviour.isDone = false;
    }
}
