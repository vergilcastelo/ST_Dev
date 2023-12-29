using UnityEngine;
using TMPro;

public class KnobDisplay : MonoBehaviour
{
    
    [SerializeField] // Serialize the knob field
    private DialRotation knob;

    [SerializeField] // Serialize the TextMeshPro field
    private TextMeshProUGUI displayText;

    void Start()
    {
         displayText.text = "starting";
        if (knob == null)
        {
            Debug.LogError("KnobValueDisplay: No knob assigned!");
            return;
        }

        if (displayText == null)
        {
            Debug.LogError("KnobValueDisplay: No TextMeshProUGUI component found!");
            return;
        }

        knob.OnValueChanged += HandleValueChanged;

    }

    private void HandleValueChanged(float value, string valueID)
    {
        
        displayText.text = $"Value: {value:F2}, ID: {valueID}, Range: {knob.MappedValue}";
    }

    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        if (knob != null)
        {
            knob.OnValueChanged -= HandleValueChanged;
        }
    }
}
