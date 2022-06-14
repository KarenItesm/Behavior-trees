using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Repeater : BT_Decorator
{
    private int repetitions, counter;
    public BT_Repeater(BT_Node child, int repetitions) : base(child) {

        this.repetitions = repetitions;
        counter = 0;
    }

    public override void Tick()
    {
        if(CurrentState == BT_States.SUCCESS)
        {
            return; //evitar que se repita una vez extra
        }

        //el hijo ya acabo
        //actualizo mi contador y reseteo hijo
        if (child.CurrentState == BT_States.SUCCESS || child.CurrentState == BT_States.FAILURE)
        {
            counter++;
            child.Reset();
        }

        //limite de cuenta, ie acabe
        if (counter == repetitions)
        {
            CurrentState = BT_States.SUCCESS;
            return;
        }

        if(CurrentState == BT_States.IDLE)
        {
            CurrentState = BT_States.RUNNING;
        }

        child.Tick();
    }

    public override void Reset()
    {
        base.Reset();
        counter = 0;
    }
}
