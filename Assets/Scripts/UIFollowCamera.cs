using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Transform target;
    private bool m_IstargetNotNull;


    private void Start()
    {
        m_IstargetNotNull = target != null;
    }

    void Update()
    {
        if (m_IstargetNotNull)
        {
            transform.rotation = target.rotation;
        }
    }
}
