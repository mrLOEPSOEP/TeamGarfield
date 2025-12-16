using UnityEngine;

public class DrillManager : MonoBehaviour
{
    public static DrillManager Instance { get; private set; }

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

    
    public void StartDrill()
    {
        Debug.Log("Drill started");
    }

    public void StopDrill()
    {
        Debug.Log("Drill stopped");
    }
}
