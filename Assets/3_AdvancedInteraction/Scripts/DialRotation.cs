using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotation : MonoBehaviour
{
    //rotationspeed how fast the dial turns when mouse moves
     private float rotationSpeed = 100f;
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation 
        //when left mouse button is released 
        if (Input.GetMouseButtonDown(0))
        {
            //track mouse position
            lastMousePosition = Input.mousePosition;
        }
        //when left mouse button 0 is held down
        if (Input.GetMouseButton(0))
        {
            //delta difference between last position and current
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;
            //angle = rotation in degrees (diff x how fast we rotate x how long rotation took)
            float angle = delta.x * rotationSpeed * Time.deltaTime;
            //rotat dial according to angle
            transform.Rotate(Vector3.forward, angle, Space.World);
        }
    }
}
