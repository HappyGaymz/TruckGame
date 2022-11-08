using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPositionSetter : MonoBehaviour
{
    [SerializeField] private WheelCollider collider;
    private void FixedUpdate()
    {
        collider.GetWorldPose(out var pos, out var rot);
        transform.SetPositionAndRotation(pos, rot);
    }
}
