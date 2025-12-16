using UnityEngine;

[CreateAssetMenu(fileName = "MaterialType", menuName = "Scriptable Objects/MaterialType")]
public class MaterialType : ScriptableObject
{
    //data for what material is the object
    public string materialName;
    //data for what rpms the material can take
    public int maxSpeed;
    public float size;

}
