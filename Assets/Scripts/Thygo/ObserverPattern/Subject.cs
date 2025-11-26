using System.Collections.Generic;
using UnityEngine;

//Using T for type so a subject can define what it wants to send out
public class Subject<T> : MonoBehaviour
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
        //{} only used on same line because its within () and part of ForEach
        observers.ForEach((observer) => { observer.OnNotify(); });
    }
}
