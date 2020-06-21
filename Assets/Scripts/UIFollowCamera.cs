using System;
using DG.Tweening;
using UnityEngine;

public class UiFollowCamera : MonoBehaviour
{
    private Camera _target;

    private void Awake() => _target = Camera.main;

    private void Update() => transform.DOLookAt(_target.transform.forward, 0);
}
