using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

//Using T for type so a subject can define what it wants to send out
public abstract class XRSubject<T> : XRBaseInteractable
{
    // collection of all observers of this subject
    private List<IAmObserver<T>> observers = new List<IAmObserver<T>>();

    //Add the observer to the subject's collection
    public void AddObserver(IAmObserver<T> observer)
    {
        observers.Add(observer);
    }

    //Remove the observer from the subject's collection
    public void RemoveObserver(IAmObserver<T> observer)
    {
        observers.Remove(observer);
    }

    //Notify each observer that an event has ocurred
    protected void NotifyObservers(T value)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(value);
        }
    }
}
