using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
Aircraft Staus Display
-displays aircraft status onscreen realtime
*/

public class AircraftStatusDisplay : MonoBehaviour
{
    //get GO
    public GameObject aircraftOne;
    //status display vars
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI shiftedPositionText;   
    //reference to Aircraft Movement Script
    private AircraftMovement aircraftMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to aircraft movements
        aircraftMovementScript = aircraftOne.GetComponent<AircraftMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Speed: " + aircraftMovementScript.speed + " km/hr";

        // Update Position Text
        positionText.text = "Position: " + aircraftOne.transform.position.ToString();

        // Update Shifted Position Text
        // For shifted position update after origin shift   
        shiftedPositionText.text = "Shifted Position: " + GetShiftedPosition();
    }

    Vector3 GetShiftedPosition()
    {
        //temp
        return  transform.position;
    }

}
