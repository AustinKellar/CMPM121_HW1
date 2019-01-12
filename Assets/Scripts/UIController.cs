﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
    // position
    private Slider xPositionSlider;
    private Slider yPositionSlider;
    private Slider zPositionSlider;

    // rotation
    private Slider xRotationSlider;
    private Slider yRotationSlider;
    private Slider zRotationSlider;

    // scale
    private Slider xScaleSlider;
    private Slider yScaleSlider;
    private Slider zScaleSlider;

    // color
    private Dropdown colorDropdown;

    // shape
    private Dropdown shapeDropdown;

    public Vector3 Position
    {
        get { return new Vector3(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value); }
    }

    public Vector3 Rotation
    {
        get { return new Vector3(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value); }
    }

    public Vector3 Scale
    {
        get { return new Vector3(xScaleSlider.value, yScaleSlider.value, zScaleSlider.value); }
    }

    public int Color 
    {
        get { return colorDropdown.value; }
    }

    public int Shape
    {
        get { return shapeDropdown.value; }
    }

	void Start () 
    {
        // position
        xPositionSlider = GameObject.Find("xPos").GetComponent<Slider>();
        yPositionSlider = GameObject.Find("yPos").GetComponent<Slider>();
        zPositionSlider = GameObject.Find("zPos").GetComponent<Slider>();

        // rotation
        xRotationSlider = GameObject.Find("xRotation").GetComponent<Slider>();
        yRotationSlider = GameObject.Find("yRotation").GetComponent<Slider>();
        zRotationSlider = GameObject.Find("zRotation").GetComponent<Slider>();

        // scale
        xScaleSlider = GameObject.Find("xScale").GetComponent<Slider>();
        yScaleSlider = GameObject.Find("yScale").GetComponent<Slider>();
        zScaleSlider = GameObject.Find("zScale").GetComponent<Slider>();

        // color
        colorDropdown = GameObject.Find("Color").GetComponent<Dropdown>();

        // shape
        shapeDropdown = GameObject.Find("Shape").GetComponent<Dropdown>();
	}
	
	void Update () 
    {
  
	}
}
