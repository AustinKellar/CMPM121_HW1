using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    private UIController uiController;
    private Renderer rend;
    private Color currentColor;

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        rend = GetComponent<Renderer>();
        currentColor = Color.blue;
        rend.material.color = Color.blue;
	}
	
	void Update () 
    {
        if (uiController.Color != currentColor)
        {
            if (uiController.Color == Color.blue)
            {
                rend.material.color = Color.blue;
            }
            else if (uiController.Color == Color.red)
            {
                rend.material.color = Color.red;
            }
            else if (uiController.Color == Color.green)
            {
                rend.material.color = Color.green;
            }
            currentColor = rend.material.color;
        }
	}
}
