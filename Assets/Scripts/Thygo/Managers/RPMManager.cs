using System;
using Unity.VRTemplate;
using UnityEngine;

public class RPMManager : Subject<RPMData>, IAmXRObserver<AxisData>
{
    //Checks the positions of the 45degree dials to form the RPM for the drill

    [SerializeField] XRSubject<AxisData> topRPMDial;
    [SerializeField] XRSubject<AxisData> bottomRPMDial;
    

    int topInput;
    int bottomInput;
    [HideInInspector] public int currentRPM;


    void Start()
    {
        topRPMDial.AddObserver(this);
        bottomRPMDial.AddObserver(this);
    }

    int[,] rpmTable = new int[2,3]
    {
        {640,   440,    150},
        {770,   530,    180}
    };

    public void OnNotify(XRSubject<AxisData> sender, AxisData data)
    {
        float dialPos = data.axisRotateValue;

        if (sender == topRPMDial)
        {
            //This sets it 0 if it is under .5 and 1 if over ? is compact if and : makes a else
            topInput = (dialPos > .5f) ? 0 : 1;
        }
        else if (sender == bottomRPMDial)
        {
            bottomInput = GetIndexFromFloat(dialPos);
        }

        currentRPM = rpmTable[topInput, bottomInput];
        
        NotifyObservers(new RPMData{RPMCurrent = currentRPM});
    }

    int GetIndexFromFloat(float value)
    {
        if (value < .25f) return 0; //Left position
        if (value < .75f) return 1; //middle pos
        return 2;                   //Right pos
    }

}
