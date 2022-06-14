using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerBehaviour : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    private Color _color;

    public int angerLevel;
    public bool isDone
    {
        get;
        set;
    }
    void OnEnable()
    {
        _color = Color.red;
        angerLevel = 0;
        isDone = false;
        StartCoroutine(DoAnger());
    }

    public void AngerRise()
    {
        angerLevel++;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoAnger()
    {
        _renderer.material.SetColor("_Color", _color);
        yield return new WaitForSeconds(3);
        Debug.Log("Anger Behaviour");
        isDone = true;
    }
}
