using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.UI;

public class MathController : MonoBehaviour {

	public enum OperationType
	{
		adition,
		substraction,
		multiplication,
		division
	}
	public enum Dificulty
	{
		easy,
		medium,
		hard
	}

	private int minValueEasyDificulty = 1;
	private int maxValueEasyDificulty = 3;
	private int minValueMediumDificulty = 2;
	private int maxValueMediumDificulty = 6;
	private int minValueHardDificulty = 4;
	private int maxValueHardDificulty = 9;

	public GestureController _gestureController;

	public OperationType currentOperation;
	public Dificulty currentDificulty;
	public int minValue;
	public int maxValue;
	public String firstValue;
	public String secondValue;
	public String resultValue;
	public Text firstValueText;
	public Text secondValueText;
	public Text resultValueText;

	public float delay;
	private float auxDelay;

	public bool isFirstOperation = true;
	
	// Use this for initialization
	void Start ()
	{
		auxDelay = delay;
		if (currentDificulty == Dificulty.easy)
		{
			setRangeValues(minValueEasyDificulty, maxValueEasyDificulty);
		} else if (currentDificulty == Dificulty.medium)
		{
			setRangeValues(minValueMediumDificulty, maxValueMediumDificulty);
		} else if (currentDificulty == Dificulty.hard)
		{
			setRangeValues(minValueHardDificulty, maxValueHardDificulty);
		}

		if (currentOperation == OperationType.adition)
		{
			firstValue = "4";
			secondValue = "2";
			resultValue = "6";
		} else if (currentOperation == OperationType.substraction)
		{
			firstValue = "4";
			secondValue = "2";
			resultValue = "6";
		} else if (currentOperation == OperationType.multiplication)
		{
			firstValue = "4";
			secondValue = "2";
			resultValue = "6";
		} else if (currentOperation == OperationType.division)
		{
			firstValue = "4";
			secondValue = "2";
			resultValue = "6";
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		firstValueText.text = firstValue;
		//secondValueText.text = secondValue;
		resultValueText.text = resultValue;
		if (_gestureController.gestureName == secondValue)
		{
			if (isFirstOperation)
			{
				GameObject[] firstOperationHelpObjects = GameObject.FindGameObjectsWithTag("FirstOperationHelp");
				foreach (var firstOperationHelpObject in firstOperationHelpObjects)
				{
					firstOperationHelpObject.SetActive(false);
				}
				isFirstOperation = false;
			}
			secondValueText.text = secondValue;
			auxDelay -= Time.deltaTime;
			if (auxDelay <= 0)
			{
				Debug.Log("score");
				_gestureController.gestureName = "";
				_gestureController.messageArea.text = "?";
				getAditionOperation();
				auxDelay = delay;
			}
		} else if (_gestureController.gestureName != "")
		{
			CameraShaker.Instance.ShakeOnce(3, 5, 2, 2);
			_gestureController.gestureName = "";
		}
	}

	void getAditionOperation()
	{
		int firstIntValue = UnityEngine.Random.Range(minValue, maxValue + 1);
		int secondIntValue = UnityEngine.Random.Range(minValue, maxValue + 1);
		int resultIntValue = firstIntValue + secondIntValue;
		firstValue = firstIntValue.ToString();
		secondValue = secondIntValue.ToString();
		resultValue = resultIntValue.ToString();
	}

	void setRangeValues(int _min, int _max)
	{
		minValue = _min;
		maxValue = _max;
	}
}
