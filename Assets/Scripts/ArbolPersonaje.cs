using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolPersonaje : MonoBehaviour
{
    private BT_RepeaterInfinite root;
    private BT_Sequence sequence;
    private BT_Denial denial;
    private BT_Anger anger;
    private BT_CheckAnger checkAnger;
    private BT_Bargaining bargaining;
    private BT_Depression depression;
    private BT_Acceptance acceptance;
    private BT_CheckAcceptance checkAcceptance;

    void Start()
    {
        sequence = new BT_Sequence();
        root = new BT_RepeaterInfinite(sequence);

        denial = new BT_Denial(GetComponent<DenialBehavior>());
        checkAnger = new BT_CheckAnger(GetComponent<AngerBehaviour>(), 5);
        anger = new BT_Anger(GetComponent<AngerBehaviour>());
        bargaining = new BT_Bargaining(GetComponent<BargainingBehaviour>());
        depression = new BT_Depression(GetComponent<DepressionBehaviour>());
        checkAcceptance = new BT_CheckAcceptance(GetComponent<AcceptanceBehaviour>(), 5);
        acceptance = new BT_Acceptance(GetComponent<AcceptanceBehaviour>());

        sequence.AddChild(denial);
        sequence.AddChild(checkAnger);
        sequence.AddChild(anger);
        sequence.AddChild(bargaining);
        sequence.AddChild(depression);
        sequence.AddChild(checkAcceptance);
        sequence.AddChild(acceptance);

        StartCoroutine(TreeTick());
    }

    IEnumerator TreeTick()
    {
        //es un loop infinito
        while (true)
        {
            root.Tick();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
