using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorForceApplier : MonoBehaviour
{
    [SerializeField] private float downforce = 50;
    [SerializeField] private float topSpeed;
    [SerializeField] private float torquePower;
    [SerializeField] private float brakePower;
    [SerializeField] private List<WheelCollider> wheels;
    Rigidbody rb;
    private float trueTopSpeed;
    private float brakeTopSpeed;
    private void Awake()
    {
        trueTopSpeed = topSpeed/3.6f;
        trueTopSpeed = trueTopSpeed * trueTopSpeed;
        brakeTopSpeed = trueTopSpeed * 1.5f;
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
        rb.AddForce(Vector3.down * downforce * rb.velocity.magnitude);
    }
}
