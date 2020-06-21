using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    private Camera _target;
    private bool _mIsTargetNotNull;


    private void Start()
    {
        _mIsTargetNotNull = _target != null;
        _target = Camera.main;
    }

    private void Update()
    {
        if (_mIsTargetNotNull)
            transform.LookAt(_target.transform);

    }
}
