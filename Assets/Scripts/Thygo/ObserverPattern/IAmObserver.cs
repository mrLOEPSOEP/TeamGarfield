using UnityEngine;

public interface IAmObserver<T>
{
    //Subject uses this method to communicate with the observer
    public void OnNotify()
    {
        
    }
}
