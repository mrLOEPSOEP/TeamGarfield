using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //Variables
    [HideInInspector] public bool languageIsDutch;
    [HideInInspector] public string gameModeSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
