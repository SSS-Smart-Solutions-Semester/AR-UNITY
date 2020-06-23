using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpiningManager : MonoBehaviour
{

	[SerializeField] private GameObject prizeWheel;
	[SerializeField] private RectTransform panelReward;
	[SerializeField] private Image prizeImage;
	[SerializeField] private TextMeshProUGUI text1;
	[SerializeField] private TextMeshProUGUI text2;

	[SerializeField] private Sprite[] imagesToUse;

	private int _randVal;
	private float _timeInterval;
	private bool _isCoroutine;
	private int _finalAngle;

	public TextMeshProUGUI winText;
	public int section;
	private float _totalAngle;
	public string[] prizeName;

	private void Start()
	{
		panelReward.DOScale(new Vector3(0, 0, 0), 0);
		_isCoroutine = true;
		_totalAngle = 360 / section;
	}

	public void OnStartSpinButtonPress()
	{
		if (!_isCoroutine) return;

		StartCoroutine(Spin());
	}
	
	public void OnTapToContinue()
	{
		
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
		
		switch (_finalAngle)
		{
			case 0:
				prizeImage.sprite = imagesToUse[0];
				text1.text = "One free drink on board !";
				text2.text = "Congratulations! You have won a free drink for your next flight";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
			case 45:
			case 270:
				prizeImage.sprite = imagesToUse[1];
				text1.text = "10% discount at musements.com !";
				text2.text = "Congratulations! You have won a 10% discount at musements.com to use the wey you want";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
			case 90:
			case 315:
				prizeImage.sprite = imagesToUse[2];
				text1.text = "One free snack on board !";
				text2.text = "Congratulations! You have won a free snack for your next flight";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
			case 135:
				prizeImage.sprite = imagesToUse[3];
				text1.text = "First lane at security check !";
				text2.text = "Congratulations! You have won a free pass to go faster through security";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
			case 180:
				prizeImage.sprite = imagesToUse[4];
				text1.text = "10% discount at bagageonline.nl !";
				text2.text = "Congratulations! You have won a 10% discount at bagageonline.nl to use the wey you want";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
			case 225:
				prizeImage.sprite = imagesToUse[3];
				text1.text = "Priority boarding !";
				text2.text = "Congratulations! You have won priority boarding for your next flight";
				panelReward.DOScale(new Vector3(1, 1, 1), 0.2f);
				break;
		}
		_isCoroutine = true;
	}
}
