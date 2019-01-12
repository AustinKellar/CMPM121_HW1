using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    private UIController uiController;
    private Renderer rend;

    private enum DropdownColor
    {
        Blue,
        Red,
        Green
    }

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        rend = GetComponent<Renderer>();	
	}
	
	void Update () 
    {
        if (uiController.Color == Convert.ToInt32(DropdownColor.Blue) && rend.material.color != Color.blue)
        {
            rend.material.color = Color.blue;
        }
        else if (uiController.Color == Convert.ToInt32(DropdownColor.Red) && rend.material.color != Color.red)
        {
            rend.material.color = Color.red;
        }
        else if (uiController.Color == Convert.ToInt32(DropdownColor.Green) && rend.material.color != Color.green)
        {
            rend.material.color = Color.green;
        }
	}
}
