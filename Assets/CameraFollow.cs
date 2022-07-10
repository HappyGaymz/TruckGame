using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] float rotateSpeed = 4f;
    [SerializeField] float followSpeed = 4f;

    [SerializeField] LayerMask roadLayer;
    [SerializeField][Range(0,90)] float angle = 14.5f;
    [SerializeField][Range(2,20)] float zOffset = 12f;
    [SerializeField][Range(2,20)] float yOffset = 5.2f;
    private void FixedUpdate()
    {
        bool didHit = Physics.Raycast(target.position,Vector3.down,out RaycastHit info,2f,roadLayer);
        Vector3 lookDirection = didHit ? info.point - transform.position : target.position - transform.position;
        lookDirection.y = 0;
        var pos = target.position + (-zOffset * lookDirection.normalized);
        pos.y += yOffset;
        var rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        Vector3 gg = rot.eulerAngles;
        gg.x = angle;
        rot.eulerAngles = gg;
        pos = Vector3.Lerp(transform.position, pos, followSpeed * Time.deltaTime);
        rot = Quaternion.Lerp(transform.rotation, rot,rotateSpeed * Time.deltaTime);
        transform.SetPositionAndRotation(pos, rot);
    }
}
