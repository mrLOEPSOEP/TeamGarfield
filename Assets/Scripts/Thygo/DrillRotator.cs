using UnityEngine;

public class DrillRotator : MonoBehaviour
{
    [SerializeField] UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable[] tableKnobs;
    [SerializeField] RPMManager rpmManager;
    bool isRunning;
    float rotationSpeed;

    void Update()
    {
        if (isRunning)
        {
            float targetVelocity = isRunning ? (rpmManager.currentRPM * 6f) : 0f;
            rotationSpeed = Mathf.Lerp(rotationSpeed, targetVelocity, Time.deltaTime * 2f);
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }
    //For the accuracy manager to know if the machine is actually running
    public bool IsMachineRunning() => isRunning;

    //Call this in the start drill button
    public void ToggleDrill()
    {
        isRunning = !isRunning;
        // Physically disable the knobs so they can't be turned at all
        foreach (var knob in tableKnobs)
        {
            if (knob != null)
        {
            // We find the 'interactable' component on the knob and disable it
            var interactable = knob.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
            if (interactable != null)
            {
                if (isRunning)
                    {
                        //Don't allow the knob to be interactable 0 = nothing in the layer mask
                        interactable.interactionLayers = 0;
                    }
                    else
                    {
                        //Set the layermask to be default again by setting to 1
                        interactable.interactionLayers = 1;
                    }
            }
        }
        }
    }

    public void EmergencyStop()
    {
        if (isRunning)
        {
            ToggleDrill();
        }
    }
}
