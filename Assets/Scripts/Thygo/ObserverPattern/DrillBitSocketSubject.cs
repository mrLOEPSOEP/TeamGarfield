using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrillBitSocketSubject : XRSubject<DrillBitData>
{
    public void OnBitEntered(SelectEnterEventArgs args)
    {
        var identity = args.interactableObject.transform.GetComponent<DrillBitIdentifier>();

        if (identity != null)
        {
            NotifyObservers(this, new DrillBitData{size = identity.bitSize, isPresent = true});
        }
    } 

    public void OnBitExited(SelectExitEventArgs args)
    {
        NotifyObservers(this, new DrillBitData{size = 0, isPresent = false});
    }
}
