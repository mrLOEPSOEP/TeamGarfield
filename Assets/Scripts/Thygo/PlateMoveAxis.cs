using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateMoveAxis : MonoBehaviour, IAmXRObserver<AxisData>
{
    //References to the cranks that move the plate and thus who the sender is
    [Header("Reference to the cranks")]
    [SerializeField] XRSubject<AxisData> crankX;
    [SerializeField] XRSubject<AxisData> crankY;
    [SerializeField] XRSubject<AxisData> crankZ;
    //Reference to the moving bottom plate of the machine
    [Header("Reference to the baseplate")]
    [SerializeField] GameObject plate;

    [Header("DrillRotator reference")]
    [SerializeField] DrillRotator drillRotator;
    
    //Dictionary to track the last value of each sender
    Dictionary<XRSubject<AxisData>, float> lastCrankValues = new Dictionary<XRSubject<AxisData>, float>();
    
    //A copy of the plates position to adjust before adjusting the actual plate pos
    Vector3 platePosition;

    //Valariables
    [Tooltip("Value of change in baseplate")][SerializeField] float scaleValue;

    //For clamping currently unused
    [Header("Clamping the positions")]
    [SerializeField] [Range(0, 1)] float clampX = 1;
    [SerializeField] [Range(0, 1)] float clampY = 1;
    [SerializeField] [Range(0, 1)] float clampZ = 1;
    


    public void OnNotify(XRSubject<AxisData> sender, AxisData axisData)
    {
        
            float currentCrankValue = axisData.axisRotateValue;
            float lastCrankValue;
            bool isFirstNotification = false; //A flag so position won't be updated at the start of the game
            platePosition = plate.transform.localPosition;

            //if there is no value in the dictionary set initial value to the current value makes sure starting delta = 0
            if (!lastCrankValues.TryGetValue(sender, out lastCrankValue))
            {
                lastCrankValue = currentCrankValue;
                lastCrankValues.Add(sender, currentCrankValue);
                isFirstNotification = true;
            }
            //calculate the change (delta) since the last update
            float crankValueDelta = currentCrankValue - lastCrankValue;

            //return if this was the first notification as to not update anything
            if(isFirstNotification)
            {
                return;
            }

            //Scale delta for movement as delta is small number  
            float scaledDelta = crankValueDelta * scaleValue;

            //Updata the stored value for the next calculation
            lastCrankValues[sender] = currentCrankValue;


            //checking who send the notification and acting correspondantly
            if(sender == crankX)
            {
                platePosition.x += scaledDelta;
            }
            else if (sender == crankY)
            {
                Debug.Log("Crank y notified");
                platePosition.y += scaledDelta; 
            }
            else if (sender == crankZ)
            {
                Debug.Log("Crank z notified");
                platePosition.z += scaledDelta;
            }
            
            plate.transform.localPosition = platePosition;
        
    }

    void OnEnable()
    {
        //Subscribes to the subjects list of observers
        if (crankX != null) crankX.AddObserver(this);
        if (crankY != null) crankY.AddObserver(this);
        if (crankZ != null) crankZ.AddObserver(this);
    }

    
    void OnDisable()
    {
        //Removes itself from the subjects list of observers
        if (crankX != null) crankX.RemoveObserver(this); 
        if (crankY != null) crankY.RemoveObserver(this);
        if (crankZ != null) crankZ.RemoveObserver(this);       
    }
}
