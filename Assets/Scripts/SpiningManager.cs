using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiningManager : MonoBehaviour
{

	[SerializeField] private GameObject prizeWheel;
	
	private int _randVal;
	private float _timeInterval;
	private bool _isCoroutine;
	private bool _coroutineHasFinished = false;
	private int _finalAngle;

	public TextMeshProUGUI winText;
	public int section;
	private float _totalAngle;
	public string[] prizeName;

	private void Start()
	{
		_isCoroutine = true;
		_totalAngle = 360 / section;
		_coroutineHasFinished = false;
	}

	public void OnstartSpinButtonPress()
	{
		if (!_isCoroutine) return;
		
		StartCoroutine(Spin());
	}

	private IEnumerator Spin()
	{

		_isCoroutine = false;
		_randVal = Random.Range(200, 300);

		_timeInterval = 0.0001f * Time.deltaTime * 2;

		for (int i = 0; i < _randVal; i++)
		{

			prizeWheel.transform.Rotate(0, 0, (_totalAngle / 2)); //Start Rotate 


			//To slow Down Wheel
			if (i > Mathf.RoundToInt(_randVal * 0.2f))
				_timeInterval = 0.5f * Time.deltaTime;
			if (i > Mathf.RoundToInt(_randVal * 0.5f))
				_timeInterval = 1f * Time.deltaTime;
			if (i > Mathf.RoundToInt(_randVal * 0.7f))
				_timeInterval = 1.5f * Time.deltaTime;
			if (i > Mathf.RoundToInt(_randVal * 0.8f))
				_timeInterval = 2f * Time.deltaTime;
			if (i > Mathf.RoundToInt(_randVal * 0.9f))
				_timeInterval = 2.5f * Time.deltaTime;

			yield return new WaitForSeconds(_timeInterval);

		}

		if (Math.Abs(Mathf.RoundToInt(prizeWheel.transform.eulerAngles.z) % _totalAngle) > 0)
			prizeWheel.transform.Rotate(0, 0, _totalAngle / 2);

		_finalAngle = Mathf.RoundToInt(prizeWheel.transform.eulerAngles.z); 
		
		for (var i = 0; i < section; i++)
		{
			if (Math.Abs(_finalAngle - i * _totalAngle) > 0) continue;
			winText.text = prizeName[i];
			
			var sequence = DOTween.Sequence();
			sequence.AppendInterval(0.2f).OnComplete(() =>
			{
				FindObjectOfType<PanelFinishController>().QuitApp();
				print("Finished");
			});
		}


		_isCoroutine = true;
	}
}
