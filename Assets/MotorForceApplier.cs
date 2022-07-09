using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorForceApplier : MonoBehaviour
{
    [SerializeField] private float torquePower;
    [SerializeField] private List<WheelCollider> wheels;
    private void FixedUpdate()
    {
        wheels.ForEach((w) => w.motorTorque = torquePower);
    }
}
