using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject MainCamera;
	public GameObject WellcomeCamera;
	public GameObject WellcomeCinematicCamera;
	
	// Use this for initialization
	void Start () {
		MainCamera.SetActive(false);
		WellcomeCamera.SetActive(true);
		WellcomeCinematicCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnableWellcomeCinematicCamera()
	{
		MainCamera.SetActive(true);
		WellcomeCamera.SetActive(false);
		WellcomeCinematicCamera.SetActive(true);
	}
}
