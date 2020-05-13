using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2movement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private void FixedUpdate()
    {
        //Moves Forward and back along z axis                           //Up/Down
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical2") * moveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal2") * moveSpeed);
    }
}
