using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelFinishController : MonoBehaviour
{
    [SerializeField] private RectTransform panelFinish;
    [SerializeField] private RectTransform topObject;
    
    public void QuitApp()
    {
        Application.Quit();
    }

    public void RescanAgain()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f);
        sequence.Append(panelFinish.DOMove(topObject.transform.position, 0.5f));
    }
}
