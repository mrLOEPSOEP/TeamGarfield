using System;
using UnityEngine;

public class AccuracyManager : MonoBehaviour,
IAmXRObserver<MaterialTypeData>,
IAmXRObserver<DrillBitData>,
IAmXRObserver<RPMData>
{
    //In this script come together a lot of the machine data to see how well the player has performed.
    //This way we can give a score for the highscore system later on

    //Store current states
    string currentMaterial;
    float currentBitSize;
    int currentRPM;

    [Header("Subjects to subscribe to")]
    [SerializeField] MaterialSocketSubject materialSocket;
    [SerializeField] DrillBitSocketSubject drillBitSocket;
    [SerializeField] RPMManager rpmManager;

    void Start()
    {
        if (materialSocket != null) materialSocket.AddObserver(this);
        if (drillBitSocket != null) drillBitSocket.AddObserver(this);
        if (rpmManager != null) rpmManager.AddObserver(this);
    }

    //Get data from the material socket
    public void OnNotify(XRSubject<MaterialTypeData> sender, MaterialTypeData data)
    {
        currentMaterial = data.isPresent ? data.type.ToString() : "None";
        DebugAllData();
    }

    //Get data from the Drill bit socket
    public void OnNotify(XRSubject<DrillBitData> sender, DrillBitData data)
    {
        currentBitSize = data.isPresent ? data.size : 0f;
        DebugAllData();
    }

    //Get data from the RPMMnager
    public void OnNotify(XRSubject<RPMData> sender, RPMData data)
    {
        currentRPM = data.RPMCurrent;
        DebugAllData();
    }

    void DebugAllData()
    {
        Debug.Log("Material: " + currentMaterial + " Drillbitsize: " + currentBitSize + " RPM: " + currentRPM);
    }

    int GetTargetRPM(string material, float bitSize)
    {
        if (material == "Steel")
        {
            if (bitSize <= 5.1f) return 2000;
            if (bitSize <= 10.1f) return 800;
            return 400;
        }
        else if (material == "Copper")
        {
            if (bitSize <= 5.1f) return 3000;
            if (bitSize <= 10.1f) return 1500;
            return 750;
        }

        //if there is no material
        return 0;
    }
    public float CalculateFloatScore()
    {
        //Find what the theaoretical ideal is for this metal for example 800
        int targetIdeal = GetTargetRPM(currentMaterial, currentBitSize);

        //Find what the best configuration of the machine is for example 770
        int bestPossibleConfig = GetClosestAvailableRPM(targetIdeal);

        // Find the rotation script
        DrillRotator rotation = FindFirstObjectByType<DrillRotator>();
        
        // If the machine isn't even turned on, they get 0 points!
        if (rotation != null && !rotation.IsMachineRunning()) 
        {
            return 0f; 
        }

        if (bestPossibleConfig == 0 || currentRPM == 0) return 0f;

        float rpmDifference = Mathf.Abs(currentRPM - bestPossibleConfig);

        //Calculate the score with decimals for the leaderboard/highscore table
        float accuracyScore = Mathf.Max(0, 100f - (rpmDifference / (float)bestPossibleConfig * 100f));

        return accuracyScore;
    } 

    int GetClosestAvailableRPM(int idealRPM)
    {
        int closestGear = 0;
        float smallestDifference = float.MaxValue;

        for (int row = 0; row < 2; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                int rpm = rpmManager.GetRPMTableValue(row, column);
                float difference = Mathf.Abs(idealRPM - rpm);

                if (difference < smallestDifference)
                {
                    smallestDifference = difference;
                    closestGear = rpm;
                }
            }
        }
        return closestGear;
    }
}
