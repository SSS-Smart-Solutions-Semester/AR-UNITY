using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeasureObject : MonoBehaviour
{
    [SerializeField] private bool height;
    [SerializeField] private bool width;
    [SerializeField] private bool lenght;
    
    [SerializeField] private GameObject cube;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (height)
        {
            text.SetText((cube.transform.localScale.y * 100).ToString());
        }
        else if (width)
        {
            text.SetText((cube.transform.localScale.z * 100).ToString());
        }
        else if (lenght)
        {
            text.SetText((cube.transform.localScale.x * 100).ToString());
        }
    }
}
