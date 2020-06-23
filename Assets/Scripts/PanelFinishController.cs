using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PanelFinishController : MonoBehaviour
{
    [SerializeField] private RectTransform panelFinish;
    [SerializeField] private RectTransform panelPrizeWheel;
    [SerializeField] private RectTransform panelContinue;
    [SerializeField] private RectTransform panelMail;
    
    [SerializeField] private RectTransform topObject;
    [SerializeField] private RectTransform middleObject;

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

    public void StartPrizeWheel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.3f);
        sequence.Append(panelPrizeWheel.DOMove(middleObject.transform.position, 0.5f));
    }

    public void FinishScan()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");      
        activity.Call("onFinishScan", measuredHeight, measuredLength, measuredWidth);
    }

    public void OnFinishButtonPress()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.3f);
        sequence.Append(panelContinue.DOMove(middleObject.transform.position, 0.5f));
    }
    
    public void OnRewardButtonPress()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.3f);
        sequence.Append(panelMail.DOMove(middleObject.transform.position, 0.5f));
    }
    
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
