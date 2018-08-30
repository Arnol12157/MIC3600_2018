using System;
using UnityEngine;
using System.Collections;
using GestureRecognizer;
using UnityEngine.UI;

public class GestureController : MonoBehaviour {

    public Text messageArea;
    public String gestureName;
     
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
        SetNumber(r.Name);
    }

    /// <summary>
    /// Shows the number
    /// </summary>
    /// <param name="text">Text to show</param>
    public void SetNumber(string text) {
        messageArea.text = text;
        gestureName = text;
    }
}
