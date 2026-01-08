using System;
using UnityEngine;

public class RPMManager : MonoBehaviour, IAmXRObserver<AxisData>
{
    //Checks the positions of the 45degree dials to form the RPM for the drill

    [SerializeField] XRSubject<AxisData> topRPMDial;
    [SerializeField] XRSubject<AxisData> bottomRPMDial;

    int topInput;
    int bottomInput;

    void Start()
    {
        topRPMDial.AddObserver(this);
        bottomRPMDial.AddObserver(this);
    }

    public void OnNotify(XRSubject<AxisData> sender, AxisData data)
    {
        if (sender == topRPMDial)
        {
            if (data.axisRotateValue == .5)
            {topInput = 0;}
            else if (data.axisRotateValue == 1)
            {topInput = 2;}
            else
            {topInput = 1;}
        }

        if (sender == bottomRPMDial)
        {
            if (data.axisRotateValue == .5)
            {bottomInput = 0;}
            else if (data.axisRotateValue == 1)
            {bottomInput = 2;}
            else
            {bottomInput = 1;}
        }

        
    }
}
