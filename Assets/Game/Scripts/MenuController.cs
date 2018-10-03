using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject optionsPanel;
	public GameObject creditsPanel;
	public GameObject mainMenuPanel;
	public string gameScene;
	
	// Singleton
	private static MenuController _instance;
	public static MenuController getInstance(){return _instance;}
	
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

	public void showCredits()
	{
		mainMenuPanel.SetActive(false);
		creditsPanel.SetActive(true);
		Credits.getInstance().beginCredits();
	}
	
	public void showMainMenu()
	{
		mainMenuPanel.SetActive(true);
		creditsPanel.SetActive(false);
	}
}
