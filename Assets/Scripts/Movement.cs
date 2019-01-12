using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    private UIController uiController;
	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
	}
	
	void Update () 
    {
        transform.position = uiController.Position;
        transform.eulerAngles = uiController.Rotation;
        transform.localScale = uiController.Scale;
	}
}
