using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionBehaviour : MonoBehaviour
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
        _color = Color.blue;
        isDone = false;
        StartCoroutine(DoDepression());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoDepression()
    {
        _renderer.material.SetColor("_Color", _color);
        yield return new WaitForSeconds(3);
        Debug.Log("Depression Behaviour");
        isDone = true;
    }
}
