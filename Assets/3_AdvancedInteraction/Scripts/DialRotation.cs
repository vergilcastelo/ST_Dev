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
        //when left mouse button 0 is held down and not snapping
        if (Input.GetMouseButton(0) && !isReturningToZero)
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
            // Apply the rotation to the GameObject
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentAngle, transform.localEulerAngles.z);
        
            //dial position or y axis due to rotation in scene
            Debug.Log("rotation is " + transform.localEulerAngles.y );
        }

         // Snap to the nearest angle when the mouse button is released and not snapping
        if (Input.GetMouseButtonUp(0) && !isReturningToZero)
        {
            SnapToClosestAngle();
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

    //snapping
     void SnapToClosestAngle()
    {
        // Snap between 22 and 40 degrees
        if (currentAngle > 22f && currentAngle < 40f)
        {
            currentAngle = 22f;
        }
        // Snap between 0 and 22 degrees
        else if (currentAngle >= 0f && currentAngle <= 22f)
        {
            currentAngle = 0f;
        }
        // Snap between 307 and 360 or (0) degrees
        else if (currentAngle >= 307f && currentAngle <= 360f)
        {
            currentAngle = 307f;
            StartCoroutine(ReturnToZeroAfterDelay(1f));
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentAngle);
    }

    //coroutine for test delay return to zero
     IEnumerator ReturnToZeroAfterDelay(float delay)
    {
        //set to condition so nothing else can happen 
        isReturningToZero = true;
        //wait
        yield return new WaitForSeconds(delay);
        //set back to 0
        currentAngle = 0f;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentAngle);
        isReturningToZero = false;
    }

}
