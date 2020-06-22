using System;
using DG.Tweening;
using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    private Camera _target;

    private void Awake() => _target = Camera.main;

    private void Update()
    {
        transform.rotation = _target.transform.rotation;
    }
}
