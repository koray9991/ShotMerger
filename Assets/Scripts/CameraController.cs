using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float IndexZ;

    private void LateUpdate()
    {
        transform.position = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z - IndexZ);
    }
}
