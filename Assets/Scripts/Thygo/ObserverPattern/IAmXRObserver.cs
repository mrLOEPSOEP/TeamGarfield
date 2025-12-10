using UnityEngine;

public interface IAmXRObserver<T>
{
    //Subject uses this method to communicate with the observer
    void OnNotify(XRSubject<T> sender, T value)
    {
        
    }
}
