
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LanguageSelect : Subject<ButtonType>
{
    [SerializeField] GameObject menuManagerObject;
    [SerializeField] GameObject gameModeCanvas;


    //Getting the gameModeSelection canvas and making sure it doesn't show up before we selected a language
    void Start()
    {
        gameModeCanvas.SetActive(false);
    }


    //Functionality of the buttons
    public void OnEnglishSelected()
    {
        NotifyObservers(ButtonType.English);
        gameObject.SetActive(false);
        gameModeCanvas.SetActive(true);
    }

    public void OnDutchSelected()
    {
        NotifyObservers(ButtonType.Dutch);
        gameObject.SetActive(false);
        gameModeCanvas.SetActive(true);
    }

}
