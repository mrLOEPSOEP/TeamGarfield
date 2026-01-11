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
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
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
                interactable.enabled = !isRunning;
            }
        }
        }
    }

    public void EmergencyStop()
    {
        isRunning = false;
    }
}
