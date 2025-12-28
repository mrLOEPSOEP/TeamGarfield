using UnityEngine;

public struct SafetyData
{
    public EquipmentType type; // reference to the safetyEquipment scripts equipmenttypes.
    public bool isPresent; // would be true if the item is in the socket false if not in it
}
