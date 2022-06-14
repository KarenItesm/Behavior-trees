using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BT_Decorator : BT_Node
{
    protected BT_Node child;

    public BT_Decorator(BT_Node child)
    {
        this.child = child;
    }

    public override void Reset()
    {
        //reset a todos los hijos
        child.Reset();

        //reset a mi estado
        CurrentState = BT_States.IDLE;
    }
}
