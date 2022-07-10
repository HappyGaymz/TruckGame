using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] float rotateSpeed = 2f;

    [SerializeField][Range(0,90)] float angle = 14.5f;
    [SerializeField][Range(2,20)] float zOffset = 12f;
    [SerializeField][Range(2,20)] float yValue = 5.2f;
    private void FixedUpdate()
    {
        var pos = target.position + (-zOffset * target.forward);
        pos.y = yValue;
        var rot = Quaternion.LookRotation(target.forward, Vector3.up);
        Vector3 gg = rot.eulerAngles;
        gg.x = angle;
        gg.z = 0;
        rot.eulerAngles = gg;
        rot = Quaternion.Lerp(transform.rotation, rot,rotateSpeed * Time.deltaTime);
        transform.SetPositionAndRotation(pos, rot);
    }
}
