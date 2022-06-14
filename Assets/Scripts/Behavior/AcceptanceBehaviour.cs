using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptanceBehaviour : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Transform _targetTransform;

    private Color _color;
    private float _relativeDistance;
    
    public float acceptanceLevel;

    public bool isDone
    {
        get;
        set;
    }
    void OnEnable()
    {
        _color = Color.green;

        DistanceCheck();

        isDone = false;
        StartCoroutine(DoAcceptance());
    }

    public void DistanceCheck()
    {
        _relativeDistance = Vector3.Distance(transform.position, _targetTransform.position);
        acceptanceLevel = _relativeDistance;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoAcceptance()
    {
        _renderer.material.SetColor("_Color", _color);
        yield return new WaitForSeconds(3);
        Debug.Log("Anger Behaviour");
        isDone = true;
    }
}
