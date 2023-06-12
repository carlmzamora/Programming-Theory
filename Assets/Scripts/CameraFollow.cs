using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.position + offset;
    }
}
