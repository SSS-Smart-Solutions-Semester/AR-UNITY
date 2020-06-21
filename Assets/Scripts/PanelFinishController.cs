using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PanelFinishController : MonoBehaviour
{
    [SerializeField] private RectTransform panelFinish;
    [SerializeField] private RectTransform topObject;
    
    [SerializeField] private TextMeshProUGUI width;
    [SerializeField] private TextMeshProUGUI height;
    [SerializeField] private TextMeshProUGUI length;

    private float measuredWidth;
    private float measuredHeight;
    private float measuredLength;
    
    private void Update()
    {
        measuredWidth = FindObjectOfType<MeasureObject>().measuredWidth;
        measuredHeight = FindObjectOfType<MeasureObject>().measuredHeight;
        measuredLength = FindObjectOfType<MeasureObject>().measuredLength;
    }
    
    public void QuitApp()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");      
        activity.Call("onFinishScan", measuredHeight, measuredLength, measuredWidth);
        //Application.Quit();
    }

    public void RescanAgain()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f);
        sequence.Append(panelFinish.DOMove(topObject.transform.position, 0.5f));
    }
}
