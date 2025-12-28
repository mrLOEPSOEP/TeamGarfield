using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SafetySocketSubject : XRSubject<SafetyData>
{
    [SerializeField] EquipmentType requiredType;

    //Call this throught the XRSocketInteractor's Select Entered event
    public void OnItemEntered(SelectEnterEventArgs args)
    {
        var equipment = args.interactableObject.transform.GetComponent<SafetyEquipment>();

        //Check if there is equipment and if it IS the required equipment and notify the observers that it is in the socket
        if (equipment != null && equipment.type == requiredType)
        {
            NotifyObservers(this, new SafetyData{type = requiredType, isPresent = true});
        }
    }

    //Call this through the XRScoketInteractor's Select Exited event
    public void OnItemExited(SelectExitEventArgs args)
    {
        var equipment = args.interactableObject.transform.GetComponent<SafetyEquipment>();

        //Check if there is equipment and if it IS the required equipment and notify the observers that it was removed from the socket
        if (equipment != null && equipment.type == requiredType)
        {
            NotifyObservers(this, new SafetyData{type = requiredType, isPresent = false});
        }
    }
}
