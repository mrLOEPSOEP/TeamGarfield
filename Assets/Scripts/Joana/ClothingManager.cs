using UnityEngine;

public class ClothingManager : MonoBehaviour
{
    public static ClothingManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool SafetyGlasses { get; private set; }
    public bool Jumpsuit { get; private set; }
    public bool SafetyShoes { get; private set; }

    public void EquipSafetyGlasses()
    {
        SafetyGlasses = true;
    }

    public void EquipJumpsuit()
    {
        Jumpsuit = true;
    }

    public void EquipSafetyShoes()
    {
        SafetyShoes = true;
    }

    public bool HasAllRequiredClothing()
    {
        return SafetyGlasses && Jumpsuit && SafetyShoes;
    }
}