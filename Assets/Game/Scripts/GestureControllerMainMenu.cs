using System;
using UnityEngine;
using System.Collections;
using GestureRecognizer;
using UnityEngine.UI;

public class GestureControllerMainMenu : MonoBehaviour {

    public String gestureName;
    public MenuController menuController;
     
    void OnEnable() {
        GestureBehaviour.OnRecognition += OnGestureRecognition;
    }

    void OnDisable() {
        GestureBehaviour.OnRecognition -= OnGestureRecognition;
    }

    void OnDestroy() {
        GestureBehaviour.OnRecognition -= OnGestureRecognition;
    }

    /// <summary>
    /// The method to be called on recognition event
    /// </summary>
    /// <param name="r">Recognition result</param>
    void OnGestureRecognition(Result r) {
        if (r.Score > 0.85f && menuController.bIsInMainMenu)
        {
            DoAnAction(r.Name);
        }
    }

    /// <summary>
    /// Shows the number
    /// </summary>
    /// <param name="text">Text to show</param>
    public void DoAnAction(string text)
    {
        gestureName = text;
        if (gestureName == "init")
        {
            menuController.toGameScene();
        } else if (gestureName == "options")
        {
            
        } else if (gestureName == "credits")
        {
            menuController.showCredits();
        } else if (gestureName == "getout")
        {
            menuController.getOutApp();
        }
    }
}
