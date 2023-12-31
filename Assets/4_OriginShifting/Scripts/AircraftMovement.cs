using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMovement : MonoBehaviour
{

    //set initial speed and range
    // Initial speed in km/hr
     public float speed = 50f;
     // Maximum speed
    private const float MaxSpeed = 500f;
     // Minimum speed
    private const float MinSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Convert speed from km/hr to meters per second for Unity units
        float speedMetersPerSecond = speed * 1000f / 3600f;
        
        // Move the plane forward
        transform.Translate(Vector3.forward * speedMetersPerSecond * Time.deltaTime);
    }

    // Public method to set speed, can be called from other scripts or UI
    public void SetSpeed(float newSpeed)
    {
        //clamp for range of speed
        speed = Mathf.Clamp(newSpeed, MinSpeed, MaxSpeed);
    }
}
