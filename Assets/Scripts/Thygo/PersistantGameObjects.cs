using UnityEngine;

public class PersistantGameObjects : MonoBehaviour
{
    //For gameObjects that need to persist throughout scenes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
