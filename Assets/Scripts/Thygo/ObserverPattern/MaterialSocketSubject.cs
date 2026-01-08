using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MaterialSocketSubject : XRSubject<MaterialTypeData>
{

    [SerializeField] private AudioSource audioSourceClamp;
    [SerializeField] private AudioClip audioCopper;
    [SerializeField] private AudioClip audioSteel;

    //Call this throught the XRSocketInteractor's Select Entered event
    public void OnItemEntered(SelectEnterEventArgs args)
    {
        var material = args.interactableObject.transform.GetComponent<MaterialTypePublish>();

        //Check if there is a material and if it IS the required material and notify the observers that it is in the socket
        if (material != null)
        {
            NotifyObservers(this, new MaterialTypeData{type = material.materialType, isPresent = true});

            if (material.materialType.materialName == "Copper")
            {
                audioSourceClamp.PlayOneShot(audioCopper);
                Debug.Log(material.materialType + " is suppose to be copper");
            }
            else if (material.materialType.materialName == "Steel")
            {
                audioSourceClamp.PlayOneShot(audioSteel);
                Debug.Log(material.materialType + " is suppose to be steel");
            }

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
