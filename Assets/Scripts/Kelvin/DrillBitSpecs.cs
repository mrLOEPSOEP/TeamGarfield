using UnityEngine;

[CreateAssetMenu(fileName = "DrillBitSpecs", menuName = "Scriptable Objects/DrillBitSpecs")]
public class DrillBitSpecs : ScriptableObject
{
    public string bitName;
    public int bitWidth;
    public int maxSpeed;
    public float bitHeight;
    public float bitHardness;
}
