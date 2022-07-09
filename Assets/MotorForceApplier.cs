using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorForceApplier : MonoBehaviour
{
    [SerializeField] private float topSpeed;
    [SerializeField] private float torquePower;
    [SerializeField] private List<WheelCollider> wheels;
    Rigidbody rb;
    private float trueTopSpeed;
    private void Awake()
    {
        trueTopSpeed = topSpeed/3.6f;
        trueTopSpeed = trueTopSpeed * trueTopSpeed;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude < trueTopSpeed)
            wheels.ForEach((w) => w.motorTorque = torquePower);
        else
            wheels.ForEach((w) => w.motorTorque = 0);
    }
}
