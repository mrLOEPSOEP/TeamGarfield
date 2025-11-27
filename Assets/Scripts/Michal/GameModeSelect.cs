using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameModeSelect : Subject<ButtonType>
{
    [SerializeField] GameObject menuManagerObject;
    MenuManager menuManager;
    int languageSelected;

    //Getting the menu manager on the actual gameobject
    void Start()
    {
        menuManager = menuManagerObject.GetComponent<MenuManager>();
    }
    //Functionality of the buttons
    public void OnGuidanceModeSelected()
    {
        NotifyObservers(ButtonType.Guidance);
    }   

    public void OnPracticeModeSelected()
    {
        NotifyObservers(ButtonType.Practice);
    } 

    public void OnChallengeModeSelected()
    {
        NotifyObservers(ButtonType.Challenge);
    }
}
