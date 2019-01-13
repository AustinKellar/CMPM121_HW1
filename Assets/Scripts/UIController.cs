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

    //  smooth movement
    private Toggle smoothMovementToggle;

    // auto pilot
    private Toggle autoPilotToggle;
    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    private float lerpSpeed = 0.02f;
    private Vector3 randomPosition;
    private Vector3 randomRotation;
    private Vector3 randomScale;

    public Vector3 Position
    {
        get { return new Vector3(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value); }
        private set
        {
            xPositionSlider.value = value.x;
            yPositionSlider.value = value.y;
            zPositionSlider.value = value.z;
        }
    }

    public Vector3 Rotation
    {
        get { return new Vector3(xRotationSlider.value, yRotationSlider.value, zRotationSlider.value); }
        private set 
        {
            xRotationSlider.value = value.x;
            yRotationSlider.value = value.y;
            zRotationSlider.value = value.z;
        }
    }

    public Vector3 Scale
    {
        get { return new Vector3(xScaleSlider.value, yScaleSlider.value, zScaleSlider.value); }
        private set
        {
            xScaleSlider.value = value.x;
            yScaleSlider.value = value.y;
            zScaleSlider.value = value.z;
        }
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

    public bool SmoothMovement
    {
        get { return smoothMovementToggle.isOn; }
    }
	
	void ClickLoad()
    {
        if (configurations.Count == 0)
        {
            return;
        }

        var selectedConfiguration = configurations[loadDropdown.value];

        // position
        Position = selectedConfiguration.position;

        // rotation
        Rotation = selectedConfiguration.rotation;

        // scale
        Scale = selectedConfiguration.scale;

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

        // smooth movement
        smoothMovementToggle.isOn = selectedConfiguration.smoothMovement;

        // auto pilot
        autoPilotToggle.isOn = selectedConfiguration.autoPilot;
    }

    void ClickSave()
    {
        configurations.Add(new Configuration(Position, Rotation, Scale, Color, Shape, SmoothMovement, this.autoPilotToggle.isOn));
        loadDropdown.AddOptions(new List<string> { "Configuration " + configurations.Count });
    }

    void Randomize()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            this.randomPosition = new Vector3(
                UnityEngine.Random.Range(xPositionSlider.minValue, xPositionSlider.maxValue),
                UnityEngine.Random.Range(yPositionSlider.minValue, yPositionSlider.maxValue),
                UnityEngine.Random.Range(zPositionSlider.minValue, zPositionSlider.maxValue)
            );

            this.randomRotation = new Vector3(
                UnityEngine.Random.Range(xRotationSlider.minValue, xRotationSlider.maxValue),
                UnityEngine.Random.Range(yRotationSlider.minValue, yRotationSlider.maxValue),
                UnityEngine.Random.Range(zRotationSlider.minValue, zRotationSlider.maxValue)
            );

            this.randomScale = new Vector3(
                UnityEngine.Random.Range(xScaleSlider.minValue, xScaleSlider.maxValue),
                UnityEngine.Random.Range(yScaleSlider.minValue, yScaleSlider.maxValue),
                UnityEngine.Random.Range(zScaleSlider.minValue, zScaleSlider.maxValue)
            );
        }

        Position = Vector3.Lerp(Position, randomPosition, lerpSpeed);
        Rotation = Vector3.Lerp(Rotation, randomRotation, lerpSpeed);
        Scale = Vector3.Lerp(Scale, randomScale, lerpSpeed);
    }

    void Start()
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

        // smooth movement
        smoothMovementToggle = GameObject.Find("Smooth Movement").GetComponent<Toggle>();

        // auto pilot
        autoPilotToggle = GameObject.Find("Auto Pilot").GetComponent<Toggle>();
    }

    void Update()
    {
        if (autoPilotToggle.isOn)
        {
            Randomize();
        }
    }

    private class Configuration
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public Color color;
        public ShapeOption shape;
        public bool smoothMovement;
        public bool autoPilot;

        public Configuration(Vector3 position, Vector3 rotation, Vector3 scale, Color color, ShapeOption shape, bool smoothMovement, bool autoPilot)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.color = color;
            this.shape = shape;
            this.smoothMovement = smoothMovement;
            this.autoPilot = autoPilot;
        }
    }
}
