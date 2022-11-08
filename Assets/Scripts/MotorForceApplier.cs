using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorForceApplier : MonoBehaviour
{
    [SerializeField] private float downforce = 50;
    [SerializeField] private float topSpeed;
    [SerializeField] private float torquePower;
    [SerializeField] private float brakeSpeedMultiplier = 2;
    [SerializeField] private float brakePower;
    [SerializeField] private List<WheelCollider> wheels;
    Rigidbody rb;
    private float trueTopSpeed;
    private float brakeTopSpeed;
    private void Awake()
    {
        trueTopSpeed = topSpeed/3.6f;
        trueTopSpeed *= trueTopSpeed;
        brakeTopSpeed = trueTopSpeed * brakeSpeedMultiplier;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude < trueTopSpeed)
        {
            wheels.ForEach((w) => w.motorTorque = torquePower);
        }
        else
        {
            wheels.ForEach((w) => w.motorTorque = 0);
        } 
        if (rb.velocity.sqrMagnitude < brakeTopSpeed)
        {
            wheels.ForEach((w) => w.brakeTorque = 0);
        }
        else
        {
            wheels.ForEach((w) => w.brakeTorque = brakePower);
        }
        rb.AddForce(downforce * rb.velocity.magnitude * Vector3.down);
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
