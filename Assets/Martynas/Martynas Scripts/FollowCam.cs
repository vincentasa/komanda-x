using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0.01f, 0.99f)] public float smoothness;
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
    }
}
