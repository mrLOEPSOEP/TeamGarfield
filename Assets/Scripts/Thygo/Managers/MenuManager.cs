using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IAmObserver<ButtonType>
{
    //Variables
    [HideInInspector] public bool languageIsDutch;
    [HideInInspector] public int gameModeSelected;
    //Subjects to subscribe to
    [SerializeField] Subject<ButtonType> languageSubject;

    void Start()
    {
        languageSubject.AddObserver(this);
        
    }
    public void OnNotify(ButtonType value)
    {
        Debug.Log(value);
        
    }

    
    void OnEnable()
    {
        //Subscribes to the subjects list of observers
    }

    
    void OnDisable()
    {
        //Removes itself from the subjects list of observers
        languageSubject.RemoveObserver(this);        
    }
}
