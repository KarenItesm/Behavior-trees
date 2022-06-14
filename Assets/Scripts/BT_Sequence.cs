using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Sequence : BT_Composite
{
    public override void Tick()
    {    
        //checa estado
        if (CurrentState == BT_States.FAILURE || CurrentState == BT_States.SUCCESS)
            return;

        //cambiar estado a running
        CurrentState = BT_States.RUNNING;

        //checa el estado del hijo actual
        if (children[currentChild].CurrentState == BT_States.FAILURE)
        {
            CurrentState = BT_States.FAILURE;
            return;
        }

        children[currentChild].Tick();

        if (children[currentChild].CurrentState == BT_States.SUCCESS)
        {
            if (currentChild == children.Count - 1)
            {
                //ya fue success el ultimo
                CurrentState = BT_States.SUCCESS;
                return;
            }
            //aun no estoy en el ultimo, me muevo al que sigue
            currentChild++;
            children[currentChild].Tick();
        }
        

    }
}
