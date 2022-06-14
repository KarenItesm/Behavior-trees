using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenialBehavior : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    private Color _color;  

    public bool isDone
    {
        get;
        set;
    }
    void OnEnable()
    {
        _color = Color.yellow;
        isDone = false;
        StartCoroutine(DoDenial());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoDenial()
    {
        _renderer.material.SetColor("_Color", _color);
        yield return new WaitForSeconds(3);
        Debug.Log("Denial Behaviour");
        isDone = true;
    }
}
