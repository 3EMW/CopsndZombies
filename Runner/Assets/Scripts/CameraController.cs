using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }   
    }
}
