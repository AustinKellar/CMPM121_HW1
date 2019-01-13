using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    private UIController uiController;
    private float movement = 0.1f;
    private float rotationSpeed = 1f;
    private float lerpSpeed = 0.01f;

    private Vector3 RoundVector(Vector3 input, int place)
    {
        return new Vector3(
            Convert.ToSingle(Math.Round(input.x, place)),  
            Convert.ToSingle(Math.Round(input.y, place)), 
            Convert.ToSingle(Math.Round(input.z, place)) 
        );
    }

    private void UpdatePosition()
    {
        if (uiController.SmoothMovement)
        {
            if (transform.position != uiController.Position)
            {
                transform.position = Vector3.Lerp(transform.position, uiController.Position, lerpSpeed);
            }
        }
        else
        {
            transform.position = uiController.Position;
        }
    }

    private void UpdateRotation()
    {
        if (uiController.SmoothMovement)
        {
            var target = new Quaternion();
            target.eulerAngles = uiController.Rotation;
            if (transform.rotation != target)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, target, lerpSpeed);
            }
        }
        else
        {
            transform.eulerAngles = uiController.Rotation;
        }
    }

    private void UpdateScale()
    {
        if (uiController.Scale != transform.localScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, uiController.Scale, lerpSpeed);
        }
        else
        {
            transform.localScale = uiController.Scale;
        }
    }

	void Start () 
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
	}
	
	void Update () 
    {
        UpdatePosition();
        UpdateRotation();
        UpdateScale();
	}
}
