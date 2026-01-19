using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrillBitSocketSubject : XRSubject<DrillBitData>
{
    [SerializeField] private AudioSource audioSourceClamp;
    [SerializeField] private AudioClip audioBit30Mm;

    public void OnBitEntered(SelectEnterEventArgs args)
    {
        var identity = args.interactableObject.transform.GetComponent<DrillBitIdentifier>();

        if (identity != null)
        {
            NotifyObservers(this, new DrillBitData{size = identity.bitSize, isPresent = true, tipLocation = identity.drillBitTip});

            if (identity.bitSize == 30)
            {
                audioSourceClamp.clip = audioBit30Mm;
                Debug.Log("Drill bit size: " + identity.bitSize);
            }
        }
    }

    public void OnBitExited(SelectExitEventArgs args)
    {
        NotifyObservers(this, new DrillBitData{size = 0, isPresent = false});
    }
}
