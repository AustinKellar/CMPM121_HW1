using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour 
{
    private UIController uiController;

    private GameObject cube;
    private GameObject sphere;
    private GameObject capsule;

    private UIController.ShapeOption currentShape;

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();

        cube = GameObject.Find("Cube");
        sphere = GameObject.Find("Sphere");
        capsule = GameObject.Find("Capsule");

        currentShape = UIController.ShapeOption.Cube;

        sphere.SetActive(false);
        capsule.SetActive(false);
	}
	
	void Update () 
    {
        var selectedShape = uiController.Shape;
        if (selectedShape != currentShape)
        {
            if (currentShape == UIController.ShapeOption.Cube)
            {
                cube.SetActive(false);
            }
            else if (currentShape == UIController.ShapeOption.Sphere)
            {
                sphere.SetActive(false);
            }
            else if (currentShape == UIController.ShapeOption.Capsule)
            {
                capsule.SetActive(false);
            }

            if (selectedShape == UIController.ShapeOption.Cube)
            {
                cube.SetActive(true);
            }
            else if (selectedShape == UIController.ShapeOption.Sphere)
            {
                sphere.SetActive(true);
            }
            else if (selectedShape == UIController.ShapeOption.Capsule)
            {
                capsule.SetActive(true);
            }

            currentShape = selectedShape;
        }
	}
}
