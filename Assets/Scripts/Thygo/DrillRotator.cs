using UnityEngine;

public class DrillRotator : MonoBehaviour
{
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
    }

    public void EmergencyStop()
    {
        isRunning = false;
    }
}
