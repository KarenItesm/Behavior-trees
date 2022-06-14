using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BT_Composite : BT_Node
{
    protected List<BT_Node> children;
    protected int currentChild;

    public BT_Composite() : base()
    {
        children = new List<BT_Node>();
        currentChild = 0;
    }

    public void AddChild(BT_Node child)
    {
        children.Add(child);
    }

    public override void Reset()
    {
        //reset a todos los hijos
        foreach (var actual in children)
        {
            actual.Reset();
        }

        //reset a mi estado
        CurrentState = BT_States.IDLE;
        currentChild = 0;
    }
}
