using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    private UIController uiController;
    private Renderer rend;

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
        rend = GetComponent<Renderer>();	
	}
	
	void Update () 
    {
        if (uiController.Color == 0)
        {
            rend.material.color = Color.blue;
        }
        else if (uiController.Color == 1)
        {
            rend.material.color = Color.red;
        }
        else
        {
            rend.material.color = Color.green;
        }
	}
}
