using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialRotation : MonoBehaviour
{
    //For range adjustments
    [SerializeField]
    private int minValue = 10; // Default value
    [SerializeField]
    private int maxValue = 75; // Default value

    //dispatch event on value change
    //delegate  
    public delegate void ValueChangedHandler(float newValue, string newValueID);
    //event
    public event ValueChangedHandler OnValueChanged;

    //rotationspeed how fast the dial turns when mouse moves
    private float rotationSpeed = 100f;
    private Vector3 lastMousePosition;

    //track angle in degrees for constraints
    private float currentAngle;
    //for test to return to after a while
    private bool isReturningToZero = false;
    //int for mapped range
    private int _mappedValue;
    public int MappedValue
    {
        get { return _mappedValue; }
        private set { _mappedValue = value; } // Make it private if you want it to be read-only
    }

    
    //value ID
    private string valueID = ""; // For storing the value ID

    //check if our mouse down is over specific GO
    private bool IsMouseOverGameObject()
    {
        //raycast for hit detection of GO
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //if our mouseclick is over the GO set to true
            if (hit.transform == transform)
            {
                return true;
            }
        }
        return false;
    }


    // Method to set the value ID
    public void SetValueID(string val)
    {
        //check changed
        if (valueID != val)
        {
            //set change
            valueID = val;
            //trigger event
            OnValueChanged?.Invoke(currentAngle, valueID);
        }
    }

    // Method to set the knob's angle
    public void SetValue(float val)
    {
        //check to see if value changed
        float oldValue = currentAngle;
        currentAngle = NormalizeAngle(val);
        ApplyRotationContraints();
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentAngle, transform.localEulerAngles.z);

        //if value changed
        if(oldValue != currentAngle)
        {
            //trigger event
             OnValueChanged?.Invoke(currentAngle, valueID);
        }
    }

    // Method to get the value ID
    public string GetValueID()
    {
        return valueID;
    }

    // Method to get the current angle of the knob
    public float GetValue()
    {
        return currentAngle;
    }
    // Start is called before the first frame update
    void Start()
    {
        //init currentAngle
        currentAngle = transform.localEulerAngles.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if our mouse is over the game object
        if (IsMouseOverGameObject())
        {
            //handle rotation if true
            HandleRotationInput();
             //Debug.Log("raycast hit object");
        }
       
    }

    //Returns an int value corresponding to the angle for the given range
    private int MapAngleToRange(float angle, float minAngle, float maxAngle, int minVal, int maxVal)
    {
        // Map the angle to the range [minValue, maxValue]
        float t = (angle - minAngle) / (maxAngle - minAngle);
        //lerping for linear interpolation then  round for whole number
        return Mathf.RoundToInt(Mathf.Lerp(minVal, maxVal, 1 - t));
    }

    //hadle the knob rotation
    private void HandleRotationInput()
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
         OnValueChanged?.Invoke(currentAngle, valueID);

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
             valueID = "ignition";
        }
        // Snap between 0 and 22 degrees
        else if (currentAngle >= 0f && currentAngle <= 22f)
        {
            currentAngle = 0f;
            valueID = "off";
        }
        // Snap between 307 and 360 or (0) degrees
        else if (currentAngle >= 307f && currentAngle <= 360f)
        {
            currentAngle = 307f;
            valueID = "test";
            StartCoroutine(ReturnToZeroAfterDelay(2f));
        }
        else
        {
            // Reset valueID if not in any specific range
            valueID = "";
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,  currentAngle, transform.localEulerAngles.z);
        
        //dial position or y axis due to rotation in scene
        Debug.Log("rotation is " + transform.localEulerAngles.y );
         //add mapping for knob range 
        if (currentAngle >= 40f && currentAngle <= 200f)
        {
            _mappedValue= MapAngleToRange(currentAngle, 40f, 200f, minValue, maxValue);
            Debug.Log("Mapped Value: " + _mappedValue);
             OnValueChanged?.Invoke(currentAngle, valueID);
        }
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
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, currentAngle,  transform.localEulerAngles.z);
        isReturningToZero = false;
    }

}
