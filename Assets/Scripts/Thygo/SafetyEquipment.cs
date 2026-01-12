using UnityEngine;


public enum EquipmentType // to be able to select the equipment type 
{
    None,
    Jumpsuit,
    SafetyGlasses,
    SafetyShoes,
    Gloves,
    Phone
}
public class SafetyEquipment : MonoBehaviour
{
    public EquipmentType type;
}
