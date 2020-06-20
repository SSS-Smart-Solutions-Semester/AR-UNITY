using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActivateHelpPanel : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private RectTransform buttonQuestionMark;
    [SerializeField] private RectTransform middleObject;

    private void Start()
    {
        var transformPosition = buttonQuestionMark.transform.position;
        panel.DOMove(new Vector3(transformPosition.x, transformPosition.y, transformPosition.z),0);
        panel.DOScale(new Vector3(0, 0, 0),0 );
    }

    public void DeactivatePanel()
    {
        var transformPosition = buttonQuestionMark.transform.position;
        
            panel.DOMove(new Vector3(transformPosition.x, transformPosition.y, transformPosition.z), 0.5f);
            panel.DOScale(new Vector3(0, 0, 0), 0.5f).OnComplete(() =>
            {
                panel.gameObject.SetActive(false);
            });
    }
    
    public void ActivatePanel()
    {
        var transformPosition = middleObject.transform.position;
        
        panel.gameObject.SetActive(true);
        panel.DOMove(new Vector3(transformPosition.x, transformPosition.y, transformPosition.z), 0.5f);
        panel.DOScale(new Vector3(1, 1, 1), 0.5f);
    }
    
    
}
