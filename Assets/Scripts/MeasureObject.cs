using System.Globalization;
using TMPro;
using UnityEngine;

public class MeasureObject : MonoBehaviour
{
    [SerializeField] private bool height;
    [SerializeField] private bool width;
    [SerializeField] private bool length;

    [SerializeField] private GameObject cube;

    [SerializeField] private Color green;
    [SerializeField] private Color red;

    private TextMeshProUGUI _text;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        meshRenderer = cube.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float measuredHeight = 0, measuredWidth = 0, measuredLength = 0;

        if (height)
        {
            measuredHeight = ((Mathf.Round(cube.transform.localScale.y * 100) * 10f) / 10f);
            _text.SetText(measuredHeight.ToString(CultureInfo.InvariantCulture) + "CM");
        }
        else if (width)
        {
            measuredWidth = ((Mathf.Round(cube.transform.localScale.z * 100) * 10f) / 10f);
            _text.SetText(measuredWidth.ToString(CultureInfo.InvariantCulture) + "CM");
        }
        else if (length)
        {
            measuredLength = ((Mathf.Round(cube.transform.localScale.x * 100) * 10f) / 10f);
            _text.SetText(measuredLength.ToString(CultureInfo.InvariantCulture) + "CM");
        }

        _text.rectTransform.localScale = new Vector3(1, 1, 1);

        Material[] materials = meshRenderer.materials;
        if (measuredLength > 40 || measuredHeight > 55 || measuredWidth > 20)
            materials[0].color = red;
        else
            materials[0].color = green;

        meshRenderer.materials = materials;
    }
}