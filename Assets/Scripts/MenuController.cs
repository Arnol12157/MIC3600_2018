using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public GameObject optionsPanel;
	public GameObject creditsPanel;
	public string gameScene;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toGameScene()
	{
		SceneManager.LoadSceneAsync(gameScene);
	}
}
