using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasureButtonController : MonoBehaviour
{
    private WebCamTexture _webCamTexture;

    [SerializeField] private RectTransform panelFinish;
    [SerializeField] private RectTransform middleObject;

    [SerializeField] private TextMeshProUGUI width;
    [SerializeField] private TextMeshProUGUI height;
    [SerializeField]private TextMeshProUGUI length;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Color green;
    [SerializeField] private Color red;

    private float measuredWidth;
    private float measuredHeight;
    private float measuredLength;

    [SerializeField] private Image luggagePhoto;
    

    public MeasureButtonController(WebCamTexture webCamTexture)
    {
        _webCamTexture = webCamTexture;
    }

    private void Start()
    {
        luggagePhoto = GetComponent<Image>();
    }

    private void Update()
    {
        measuredWidth = FindObjectOfType<MeasureObject>().measuredWidth;
        measuredHeight = FindObjectOfType<MeasureObject>().measuredHeight;
        measuredLength = FindObjectOfType<MeasureObject>().measuredLength;
    }

    public void OnMeasureButtonPressed()
    {
        width.text = measuredWidth.ToString(CultureInfo.InvariantCulture);
        height.text = measuredHeight.ToString(CultureInfo.InvariantCulture);
        length.text = measuredLength.ToString(CultureInfo.InvariantCulture);

        if (measuredHeight > 55 || measuredWidth > 20 || measuredLength > 40)
        {
            _text.text =
                "Oops... Your bag does not fit the dimensions of \n TUI Fly. Verify if the dimensions are correct by \n rescanning the luggage.";
            width.color = red;
            height.color = red;
            length.color = red;
        }
        else
        {
            _text.text =
                "Perfect! Your bag fits the dimensions of TUI Fly. \n You are one more step closer to your \n holiday destination.";

            width.color = green;
            height.color = green;
            length.color = green;
        }

        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f);
        sequence.Append(panelFinish.DOMove(middleObject.transform.position, 0.5f));

        //StartCoroutine(TakePhoto());
    }


    private IEnumerator TakePhoto() // Start this Coroutine on some button click
    {
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(_webCamTexture.width, _webCamTexture.height);
        photo.SetPixels(_webCamTexture.GetPixels());
        photo.Apply();
        
        Rect rec = new Rect(0, 0, photo.width, photo.height);
        Sprite.Create(photo,rec,new Vector2(0,0),1);

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG
        File.WriteAllBytes("photo.png", bytes);
        
        
    }
}
