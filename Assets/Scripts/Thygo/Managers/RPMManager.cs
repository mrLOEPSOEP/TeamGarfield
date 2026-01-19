using System;
using Unity.VRTemplate;
using UnityEngine;

public class RPMManager : XRSubject<RPMData>, IAmXRObserver<AxisData>
{
    //Checks the positions of the 45degree dials to form the RPM for the drill

    [Tooltip("Dial with only 2 posiible values")][SerializeField] XRSubject<AxisData> topRPMDial;
    [Tooltip("Dial with 3 posible values")][SerializeField] XRSubject<AxisData> bottomRPMDial;
    

    int topInput = 0;
    int bottomInput = 1;
    [HideInInspector] public int currentRPM;


    void Start()
    {
        topRPMDial.AddObserver(this);
        bottomRPMDial.AddObserver(this);
    }

    int[,] rpmTable = new int[2,3]
    {
        {640,   1280,    440},
        {770,   1540,    530}
    };

    public void OnNotify(XRSubject<AxisData> sender, AxisData data)
    {
        float dialPos = data.axisRotateValue;

        if (sender == topRPMDial)
        {
            //This sets it 0 if it is under .5 and 1 if over ? is compact if and : makes a else
            topInput = (dialPos < .5f) ? 0 : 1;
        }
        else if (sender == bottomRPMDial)
        {
            bottomInput = GetIndexFromFloat(dialPos);
        }

        currentRPM = rpmTable[topInput, bottomInput];
        
        NotifyObservers(this, new RPMData{RPMCurrent = currentRPM});
    }

    int GetIndexFromFloat(float value)
    {
        if (value < .25f) return 0; //Left position
        if (value < .75f) return 1; //middle pos
        return 2;                   //Right pos
    }

    //To allow the AccuracyManager to read the rpmTable
    public int GetRPMTableValue(int row, int column)
    {
        return rpmTable[row, column];
    }

}
