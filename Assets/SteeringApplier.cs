using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringApplier : MonoBehaviour
{
    [SerializeField] private List<WheelCollider> wheels;
    [SerializeField] private float maxAngle;
    private void FixedUpdate()
    {
        float angle = maxAngle * Input.GetAxis("Horizontal");
        wheels.ForEach((w) => w.steerAngle = angle);
    }
}
