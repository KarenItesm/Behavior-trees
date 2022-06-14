using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Selector : BT_Composite
{
    public override void Tick()
    {
        //checa estado
        if (CurrentState == BT_States.FAILURE || CurrentState == BT_States.SUCCESS)
            return;

        //cambiar a running
        CurrentState = BT_States.RUNNING;

        //checa hijo actual
        //si tuve exito, me regreso
        if (children[currentChild].CurrentState == BT_States.SUCCESS)
        {
            CurrentState = BT_States.SUCCESS;
            return;
        }
        else if (children[currentChild].CurrentState == BT_States.FAILURE)
        {
            //checa si es el ultimo
            if (currentChild == children.Count - 1)
            {
                CurrentState = BT_States.FAILURE;
                return;
            }

            //aun no estoy en el ultimo, me muevo al que sigue
            currentChild++;
        }

        children[currentChild].Tick();
    }
}
