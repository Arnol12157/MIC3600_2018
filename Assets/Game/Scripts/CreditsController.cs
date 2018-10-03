using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{

	public bool bCreditsStarted;
	
	void Start()
	{
		// Starting manually the credit roll if "Play On Awake" is false:
		//Credits.getInstance().beginCredits();

		// You can also do localization with PlayOnAwake false and setting the file before starting:
		//Credits c = Credits.getInstance();
		//c.creditsFile = Resources.Load<TextAsset>("credits/enEN");
		//c.beginCredits();

		// Callback
		if (Credits.getInstance() != null)
		{
			bCreditsStarted = true;
			Credits.getInstance().endListeners += new Credits.CreditsEndListener(creditsEnded); // creditsEnded is the name of the function
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Callback
		if (Credits.getInstance() != null && !bCreditsStarted)
		{
			bCreditsStarted = true;
			Credits.getInstance().endListeners += new Credits.CreditsEndListener(creditsEnded); // creditsEnded is the name of the function
		}
	}
	
	void creditsEnded(Credits c)
	{
		c.started = false;
		GameObject.Find("CanvasMain").GetComponent<MenuController>().showMainMenu();
		Debug.Log("Credit roll finished!");
	}
}
