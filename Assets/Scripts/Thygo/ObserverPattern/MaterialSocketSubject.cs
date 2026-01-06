using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaterialSocketSubject : XRSubject<MaterialTypeData>
{
    //Call this throught the XRSocketInteractor's Select Entered event
    public void OnItemEntered(SelectEnterEventArgs args)
    {
        var material = args.interactableObject.transform.GetComponent<MaterialTypePublish>();

        //Check if there is a material and if it IS the required material and notify the observers that it is in the socket
        if (material != null)
        {
            NotifyObservers(this, new MaterialTypeData{type = material.materialType, isPresent = true});
            Debug.Log(material.materialType);
        }
    }

    //Call this through the XRScoketInteractor's Select Exited event
    public void OnItemExited(SelectExitEventArgs args)
    {
        var material = args.interactableObject.transform.GetComponent<MaterialTypePublish>();

        //Check if there is a material and if it IS the required material and notify the observers that it was removed from the socket
        if (material != null)
        {
            NotifyObservers(this, new MaterialTypeData{type = material.materialType, isPresent = false});
        }
    }
}