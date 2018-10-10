using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	
	public enum GameState
	{
		StageArea,
		InitGame,
		Playing,
		GameOver
	}
	public GameState gameState;
	public int currentScore;
	public Text scoreText;
	public int currentTimer;
	public Text timerText;
	public int alarmTimeLess = 60;
	public AudioClip soundTimeLess;
	[Range(0,1)]
	public float soundTimeLessVolume = 0.5f;
	public AudioClip soundTimeUp;
	[Range(0,1)]
	public float soundTimeUpVolume = 0.5f;

	public GameObject loadingScreenPanel;
	public GameObject finishLevelPanel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreText.text = currentScore.ToString();
		timerText.text = currentTimer.ToString();
		if (gameState == GameState.InitGame)
		{
			StartCoroutine (CountDownTimer ());
			gameState = GameState.Playing;
		} else if (gameState == GameState.GameOver)
		{
			ShowFinishLevelPanel();
		} 
	}
	
	IEnumerator CountDownTimer(){
		yield return new WaitForSeconds (1);

		if (gameState == GameState.GameOver)
			yield break;

		currentTimer--;
		if (currentTimer == alarmTimeLess)
			SoundManager.PlaySfx (soundTimeLess, soundTimeLessVolume);
		else if (currentTimer <= 0) {
			SoundManager.PlaySfx (soundTimeUp, soundTimeUpVolume);
			//KillPlayer ();
			gameState = GameState.GameOver;
		}

		if (currentTimer > 0)
			StartCoroutine (CountDownTimer ());
	}

	public void ToMainMenu()
	{
		ShowLoadingScreen();
		SceneManager.LoadSceneAsync("MainMenu");
	}

	public void ShowLoadingScreen()
	{
		loadingScreenPanel.SetActive(true);
	}

	public void ShowFinishLevelPanel()
	{
		finishLevelPanel.SetActive(true);
	}
}
