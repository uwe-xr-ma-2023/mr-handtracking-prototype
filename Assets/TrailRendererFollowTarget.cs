using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererFollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 offset;
    void Start()
    {
        transform.position = TargetPositionWithOffset(target);
    }

    private Vector3 TargetPositionWithOffset(Transform controllerTarget)
    {
        return target.position + offset;
    }

    private void Update()
    {
        Vector3 targetPositionWithOffset = TargetPositionWithOffset(target);
        transform.position = Vector3.Lerp(transform.position, targetPositionWithOffset, speed * Time.deltaTime);
    }
}