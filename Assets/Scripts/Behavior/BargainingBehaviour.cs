using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainingBehaviour : MonoBehaviour
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
        _color = Color.magenta;
        isDone = false;
        StartCoroutine(DoBargaining());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoBargaining()
    {
        _renderer.material.SetColor("_Color", _color);
        yield return new WaitForSeconds(3);
        Debug.Log("Bargaining Behaviour");
        isDone = true;
    }
}
