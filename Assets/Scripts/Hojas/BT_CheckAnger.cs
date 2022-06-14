using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_CheckAnger : BT_Node
{
    //checate si el behavior que debería venir aqui no es mas bien lo que quieres qeu corra?
    private AngerBehaviour behaviour;
    private int angerTreshold;

    public BT_CheckAnger(AngerBehaviour behaviour,int angerTreshold)
    {
        this.behaviour = behaviour;
        this.angerTreshold = angerTreshold;
    }

    public override void Tick()
    {
        Debug.Log($"Tick en BT CheckAnger {CurrentState}, Level: {behaviour.angerLevel}");

        if (CurrentState == BT_States.IDLE)
        {
            //behaviour.enabled = true;
            CurrentState = BT_States.RUNNING;
        }

        behaviour.AngerRise();
        //si estoy corriendo, entonces reviso nivel de ira
        //esto es si te esperas hasta que llegue al nivel... si es inmediato
        //entonces necesitas un else que haga failure
        if (CurrentState == BT_States.RUNNING)
        {
            if (behaviour.angerLevel >= angerTreshold)
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
