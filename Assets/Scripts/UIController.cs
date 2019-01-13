using System;
using System.Collections;
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
    public enum ShapeOption
    {
        Cube,
        Sphere,
        Capsule
    }

    // save / load
    private Dropdown loadDropdown;
    private Button loadButton;
    private Button saveButton;
    private List<Configuration> configurations;

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

    public Color Color 
    {
        get 
        { 
            if (colorDropdown.value == 0)
            {
                return Color.blue;
            }
            else if (colorDropdown.value == 1)
            {
                return Color.red;
            }
            else
            {
                return Color.green;
            }
        }
    }

    public ShapeOption Shape
    {
        get 
        { 
            if (shapeDropdown.value == 0)
            {
                return ShapeOption.Cube;
            }
            else if (shapeDropdown.value == 1)
            {
                return ShapeOption.Sphere;
            }
            else
            {
                return ShapeOption.Capsule;
            }
        }
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

        // save / load
        loadDropdown = GameObject.Find("LoadOptions").GetComponent<Dropdown>();
        loadButton = GameObject.Find("Load").GetComponent<Button>();
        saveButton = GameObject.Find("Save").GetComponent<Button>();
        loadButton.onClick.AddListener(ClickLoad);
        saveButton.onClick.AddListener(ClickSave);
        configurations = new List<Configuration>();
	}
	
	void ClickLoad()
    {
        if (configurations.Count == 0)
        {
            return;
        }

        var selectedConfiguration = configurations[loadDropdown.value];

        // position
        xPositionSlider.value = selectedConfiguration.position.x;
        yPositionSlider.value = selectedConfiguration.position.y;
        zPositionSlider.value = selectedConfiguration.position.z;

        // rotation
        xRotationSlider.value = selectedConfiguration.rotation.x;
        yRotationSlider.value = selectedConfiguration.rotation.y;
        zRotationSlider.value = selectedConfiguration.rotation.z;

        // scale
        xScaleSlider.value = selectedConfiguration.scale.x;
        yScaleSlider.value = selectedConfiguration.scale.y;
        zScaleSlider.value = selectedConfiguration.scale.z;

        // color
        if (selectedConfiguration.color == Color.blue)
        {
            colorDropdown.value = 0;
        }
        else if (selectedConfiguration.color == Color.red)
        {
            colorDropdown.value = 1;
        }
        else if (selectedConfiguration.color == Color.green)
        {
            colorDropdown.value = 2;
        }

        // shape
        shapeDropdown.value = Convert.ToInt32(selectedConfiguration.shape);
    }

    void ClickSave()
    {
        configurations.Add(new Configuration(Position, Rotation, Scale, Color, Shape));
        loadDropdown.AddOptions(new List<string> { "Configuration " + configurations.Count });
    }

    private class Configuration
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public Color color;
        public ShapeOption shape;

        public Configuration(Vector3 position, Vector3 rotation, Vector3 scale, Color color, ShapeOption shape)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.color = color;
            this.shape = shape;
        }
    }
}
