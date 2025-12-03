using UnityEngine;

public class PlateMoveAxis : MonoBehaviour, IAmObserver<AxisData>
{
    [SerializeField] XRSubject<AxisData> crank;
    Vector3 platePosition;

    void Start()
    {
        platePosition = transform.position;
    }
    public void OnNotify(AxisData axisData)
    {
        platePosition.x += axisData.xAxis;
        platePosition.z += axisData.zAxis;
    }

    void OnEnable()
    {
        //Subscribes to the subjects list of observers
        crank.AddObserver(this);
    }

    
    void OnDisable()
    {
        //Removes itself from the subjects list of observers
        crank.RemoveObserver(this);        
    }
}
