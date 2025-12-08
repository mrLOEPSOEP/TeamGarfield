using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private MaterialType materialType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(materialType.materialName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
