using UnityEngine;
using UnityEngine.UI;

public class PlateMoveAxis : MonoBehaviour, IAmXRObserver<AxisData>
{
    [SerializeField] XRSubject<AxisData> crankX;
    [SerializeField] XRSubject<AxisData> crankY;
    [SerializeField] XRSubject<AxisData> crankZ;
    [SerializeField] GameObject plate;
    Vector3 platePosition;
    float scaledValue;

    void Start()
    {
        platePosition = transform.position;
    }
    public void OnNotify(XRSubject<AxisData> sender, AxisData axisData)
    {
        scaledValue = axisData.axisRotateValue * 100;
        Debug.Log("sender is " + sender);
        if(sender == crankX)
        {
            platePosition.x += scaledValue;
            Debug.Log("CrankX should've done something");
        }
        else if (sender == crankY)
        {
            platePosition.y += scaledValue;
            Debug.Log("PlateposY = " + platePosition.y);  
        }
        else if (sender == crankZ)
        {
            platePosition.y += scaledValue;
        }
        
        plate.transform.position = platePosition;
    }

    void OnEnable()
    {
        //Subscribes to the subjects list of observers
        crankX.AddObserver(this);
        crankY.AddObserver(this);
        crankZ.AddObserver(this);
    }

    
    void OnDisable()
    {
        //Removes itself from the subjects list of observers
        crankX.RemoveObserver(this); 
        crankY.RemoveObserver(this);
        crankZ.RemoveObserver(this);       
    }
}
