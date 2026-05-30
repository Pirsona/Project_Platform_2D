using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        Follow();   
    }

    private void Follow()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }    
    }
}