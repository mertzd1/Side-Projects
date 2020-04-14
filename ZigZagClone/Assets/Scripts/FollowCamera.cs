using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
     void Awake()
     {
        offset = transform.position - target.position;   
     }
    //this is used for camera updates
    private void LateUpdate()
    {
        //the offset funciton keeps the camera from being inside our player

        transform.position = target.position + offset;
    }
}
