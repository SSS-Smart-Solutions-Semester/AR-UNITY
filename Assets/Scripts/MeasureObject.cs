using System.Globalization;
using TMPro;
using UnityEngine;

public class MeasureObject : MonoBehaviour
{
    //[SerializeField] private GameObject cube;

    [SerializeField] private Color green;
    [SerializeField] private Color red;

    [SerializeField] private TextMeshProUGUI heightText;
    [SerializeField] private TextMeshProUGUI widthText;
    [SerializeField] private TextMeshProUGUI lengthText;

    private MeshRenderer _meshRenderer;

    public float measuredHeight, measuredWidth, measuredLength;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        measuredHeight = ((Mathf.Round(transform.localScale.y * 100) * 10f) / 10f);
        heightText.SetText(measuredHeight.ToString(CultureInfo.InvariantCulture) + "CM");

        measuredWidth = ((Mathf.Round(transform.localScale.z * 100) * 10f) / 10f);
        widthText.SetText(measuredWidth.ToString(CultureInfo.InvariantCulture) + "CM");

        measuredLength = ((Mathf.Round(transform.localScale.x * 100) * 10f) / 10f);
        lengthText.SetText(measuredLength.ToString(CultureInfo.InvariantCulture) + "CM");

        heightText.rectTransform.localScale = new Vector3(1, 1, 1);
        widthText.rectTransform.localScale = new Vector3(1, 1, 1);
        lengthText.rectTransform.localScale = new Vector3(1, 1, 1);

        var materials = _meshRenderer.materials;
        if (measuredLength > 40 || measuredHeight > 55 || measuredWidth > 20)
            materials[0].color = red;
        else
            materials[0].color = green;

        _meshRenderer.materials = materials;
    }
}