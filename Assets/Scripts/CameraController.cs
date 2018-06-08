using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;

    private Vector3 positionDifference;

    void Start()
    {
        positionDifference = transform.position - Target.position;
    }

    void LateUpdate()
    {
        transform.position = Target.position + positionDifference;
    }
}
