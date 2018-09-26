using System;
using UnityEngine;
using System.Collections;

public class GlobalValue : MonoBehaviour {
	public static int worldPlaying = 1;
	public static int levelPlaying = 1;

	public static string WorldReached = "WorldReached";
	public static string Coins = "Coins";
	public static string Lives = "Lives";
	public static string Points = "Points";
	public static string Bullets = "Bullets";
	public static string Character = "Character";
	public static string ChoosenCharacterID = "choosenCharacterID";
	public static string ChoosenCharacterInstanceID = "ChoosenCharacterInstanceID";
	public static GameObject CharacterPrefab;
	public static bool isSound = true;
	public static bool isMusic = true;
	public static bool isFirstTime = true;
//	public static bool isRestart = false;
//
//	public static int levelPlaying = 1;	//default = 1, this value is set by Level script, Level object in Menu scene

	void Start()
	{
		if (PlayerPrefs.HasKey("isFirstTime"))
		{
			isFirstTime = false;
		}
		if (PlayerPrefs.HasKey("isSound"))
		{
			isSound = PlayerPrefs.GetString("isSound") == "true";
		}
		else
		{
			PlayerPrefs.SetString("isSound", "true");
		}
		
		if (PlayerPrefs.HasKey("isMusic"))
		{
			isMusic = PlayerPrefs.GetString("isMusic") == "true";
		}
		else
		{
			PlayerPrefs.SetString("isMusic", "true");
		}
	}

	public static int SavedCoins{ 
		get { 
			if(!PlayerPrefs.HasKey(Coins))
				PlayerPrefs.SetInt (Coins, 25);
			
			return PlayerPrefs.GetInt (Coins, 0); } 
		set { PlayerPrefs.SetInt (Coins, value); } 
	}
}
