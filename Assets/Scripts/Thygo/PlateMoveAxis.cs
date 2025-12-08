using UnityEngine;
using UnityEngine.UI;

public class PlateMoveAxis : MonoBehaviour, IAmObserver<AxisData>
{
    [SerializeField] XRSubject<AxisData> crank;
    [SerializeField] GameObject plate;
    Vector3 platePosition;

    [SerializeField] bool moveTypeX;
    [SerializeField] bool moveTypeY;
    [SerializeField] bool moveTypeZ;

    void Start()
    {
        platePosition = transform.position;
    }
    public void OnNotify(AxisData axisData)
    {
        platePosition.x += axisData.axisRotateValue;
        
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
