using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualReward : MonoBehaviour
{
	public GameObject[] numbers;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetNumberAnimation(int index)
	{
		return numbers[index];
	}
}
