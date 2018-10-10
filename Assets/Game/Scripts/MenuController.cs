using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject loadingScreen;
	public GameObject optionsPanel;
	public GameObject creditsPanel;
	public GameObject mainMenuPanel;
	public string gameScene;
	public bool bIsInMainMenu;
	
	// Singleton
	private static MenuController _instance;
	public static MenuController getInstance(){return _instance;}
	
	// Use this for initialization
	void Start ()
	{
		bIsInMainMenu = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toGameScene()
	{
		bIsInMainMenu = false;
		showLoadingScreen();
		SceneManager.LoadSceneAsync(gameScene);
	}

	public void showCredits()
	{
		bIsInMainMenu = false;
		mainMenuPanel.SetActive(false);
		creditsPanel.SetActive(true);
		Credits.getInstance().beginCredits();
	}
	
	public void showMainMenu()
	{
		bIsInMainMenu = true;
		mainMenuPanel.SetActive(true);
		creditsPanel.SetActive(false);
	}

	public void showLoadingScreen()
	{
		loadingScreen.SetActive(true);
	}

	public void getOutApp()
	{
		Application.Quit();
	}
}
