using System.Globalization;
using TMPro;
using UnityEngine;

public class MeasureObject : MonoBehaviour
{
    [SerializeField] private bool height;
    [SerializeField] private bool width;
    [SerializeField] private bool length;
    
    [SerializeField] private GameObject cube;

    [SerializeField] private Material green;
    [SerializeField] private Material red;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (height)
            _text.SetText(((Mathf.Round(cube.transform.localScale.y * 100) * 10f) / 10f).ToString(CultureInfo.InvariantCulture) + "CM");
        else if (width)
            _text.SetText(((Mathf.Round(cube.transform.localScale.z * 100) * 10f) / 10f).ToString(CultureInfo.InvariantCulture) + "CM");
        else if (length)
            _text.SetText(((Mathf.Round(cube.transform.localScale.x * 100) * 10f) / 10f).ToString(CultureInfo.InvariantCulture) + "CM");

        _text.rectTransform.localScale = new Vector3(1,1,1);

        if (cube.transform.localScale.x > 40 || cube.transform.localScale.y > 55 || cube.transform.localScale.z > 20)
            cube.GetComponent<MeshRenderer>().material = red;
        else
            cube.GetComponent<MeshRenderer>().material = green;

    }
}
