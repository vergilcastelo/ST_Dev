using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotation : MonoBehaviour
{
    //rotationspeed how fast the dial turns when mouse moves
     private float rotationSpeed = 100f;
    private Vector3 lastMousePosition;

    //track angle in degrees for constraints
    private float currentAngle;
    //for test to return to after a while
    private bool isReturningToZero = false;

    // Start is called before the first frame update
    void Start()
    {
        //init currentAngle
        currentAngle = transform.localEulerAngles.y;
        
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

            currentAngle += angle;
            
            //apply constraints before rotating
            ApplyRotationContraints();

            //rotat dial according to angle
            transform.Rotate(Vector3.forward, angle, Space.World);

            //dial position or y axis due to rotation in scene
            Debug.Log("rotation is " + transform.localEulerAngles.y );
            
           

        }
    }

    //off is 0, ignition is 22, 70 is 40, 10 is 200, test 307
    //stop rotation between 10 and test
    void ApplyRotationContraints()
    {
        // Clamp the angle
        currentAngle = NormalizeAngle(currentAngle);

        // Prevent rotation between 201 and 306 degrees
        if (currentAngle > 200f && currentAngle < 307f)
        {
            currentAngle = (currentAngle < 253.5f) ? 200f : 307f;
        }
    }

    //keep 360 rotation
    float NormalizeAngle(float angl)
    {
        // Normalize the angle to be within 0 to 360 degrees
        while (angl < 0f) angl += 360f;
        while (angl > 360f) angl -= 360f;
        return angl;
    }
}
