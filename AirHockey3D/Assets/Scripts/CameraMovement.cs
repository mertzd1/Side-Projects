using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam; //it is serialized so it shows up in the inspector
    [SerializeField] private Transform target;

    private Vector3 previousPosition;
    private void Update()
    {
        //zero is the left mouse button and will start our movement
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            //cam.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.y * 180);
            //cam.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * 180);
            //setting the cameral to target.position keeps the camera where the sphere goes
            cam.transform.position = target.position;  //new Vector3();
            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World); //space.world is the key 
            cam.transform.Translate(new Vector3(0, 0, -10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        
    }

}
