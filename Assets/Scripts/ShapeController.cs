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

    private enum Shape
    {
        Cube,
        Sphere,
        Capsule
    }

    private Shape currentShape;

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();

        cube = GameObject.Find("Cube");
        sphere = GameObject.Find("Sphere");
        capsule = GameObject.Find("Capsule");

        currentShape = Shape.Cube;

        sphere.SetActive(false);
        capsule.SetActive(false);
	}
	
	void Update () 
    {
        var selectedShape = uiController.Shape;
        if (selectedShape != Convert.ToInt32(currentShape))
        {
            if (currentShape == Shape.Cube)
            {
                cube.SetActive(false);
            }
            else if (currentShape == Shape.Sphere)
            {
                sphere.SetActive(false);
            }
            else if (currentShape == Shape.Capsule)
            {
                capsule.SetActive(false);
            }

            if (selectedShape == Convert.ToInt32(Shape.Cube))
            {
                cube.SetActive(true);
            }
            else if (selectedShape == Convert.ToInt32(Shape.Sphere))
            {
                sphere.SetActive(true);
            }
            else if (selectedShape == Convert.ToInt32(Shape.Capsule))
            {
                capsule.SetActive(true);
            }

            currentShape = (Shape)selectedShape;
        }
	}
}
