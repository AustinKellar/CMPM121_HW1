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
            Transform prevTransform;
            if (currentShape == UIController.ShapeOption.Cube)
            {
                prevTransform = cube.transform;
                cube.SetActive(false);
            }
            else if (currentShape == UIController.ShapeOption.Sphere)
            {
                prevTransform = sphere.transform;
                sphere.SetActive(false);
            }
            else 
            {
                prevTransform = capsule.transform;
                capsule.SetActive(false);
            }

            if (selectedShape == UIController.ShapeOption.Cube)
            {
                cube.SetActive(true);
                cube.transform.position = prevTransform.position;
                cube.transform.rotation = prevTransform.rotation;
                cube.transform.localScale = prevTransform.localScale;

            }
            else if (selectedShape == UIController.ShapeOption.Sphere)
            {
                sphere.SetActive(true);
                sphere.transform.position = prevTransform.position;
                sphere.transform.rotation = prevTransform.rotation;
                sphere.transform.localScale = prevTransform.localScale;
            }
            else if (selectedShape == UIController.ShapeOption.Capsule)
            {
                capsule.SetActive(true);
                capsule.transform.position = prevTransform.position;
                capsule.transform.rotation = prevTransform.rotation;
                capsule.transform.localScale = prevTransform.localScale;
            }

            currentShape = selectedShape;
        }
	}
}
