using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MeasureButtonController : MonoBehaviour
{
    private WebCamTexture _webCamTexture;

    [SerializeField] private RectTransform panelFinish;
    [SerializeField] private RectTransform middleObject;

    [SerializeField] private TextMeshProUGUI width;
    [SerializeField] private TextMeshProUGUI height;
    [SerializeField]private TextMeshProUGUI length;

    [SerializeField] private TextMeshProUGUI _text;

    private float measuredWidth;
    private float measuredHeight;
    private float measuredLength;
    
    

    public MeasureButtonController(WebCamTexture webCamTexture)
    {
        _webCamTexture = webCamTexture;
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

        if (measuredHeight > 55 || measuredWidth > 40 || measuredLength > 20)
        {
            _text.text =
                "Oops... Your bag does not fit the dimensions of \n TUI Fly. Verify if the dimensions are correct by \n rescanning the luggage.";
            width.color = Color.red;
            height.color = Color.red;
            length.color = Color.red;
        }
        else
        {
            _text.text =
                "Perfect! Your bag fits the dimensions of TUI Fly. \n You are one more step closer to your \n holiday destination.";
            width.color = Color.green;
            height.color = Color.green;
            length.color = Color.green;
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

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG
        File.WriteAllBytes("photo.png", bytes);
    }
}
