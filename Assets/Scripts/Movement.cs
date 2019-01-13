using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private UIController uiController;
    private float lerpSpeed = 0.02f;

    private Vector3 RoundVector(Vector3 input, int place)
    {
        return new Vector3(
            Convert.ToSingle(Math.Round(input.x, place)),
            Convert.ToSingle(Math.Round(input.y, place)),
            Convert.ToSingle(Math.Round(input.z, place))
        );
    }

    void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    void Update()
    {
        if (uiController.SmoothMovement)
        {
            transform.position = Vector3.Lerp(transform.position, uiController.Position, lerpSpeed);

            var target = new Quaternion();
            target.eulerAngles = uiController.Rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, target, lerpSpeed);

            transform.localScale = Vector3.Lerp(transform.localScale, uiController.Scale, lerpSpeed);
        }
        else
        {
            transform.position = uiController.Position;
            transform.eulerAngles = uiController.Rotation;
            transform.localScale = uiController.Scale;
        }
    }
}
