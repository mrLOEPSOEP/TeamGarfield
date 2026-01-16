using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IAmObserver<ButtonType>
{
    //Subjects to subscribe to
    [SerializeField] Subject<ButtonType> languageSubject;
    
    //Variables
    bool languageIsDutch;
    bool languageIsEnglish;

    //references
    [Header("Canvas' with buttons")]
    [SerializeField] GameObject gamemodeSelectCanvas;
    [SerializeField] GameObject languageSelectCanvas;
    [Header("Textfields of the buttons")]
    [SerializeField] TMP_Text guidanceText;
    [SerializeField] TMP_Text practiceText;    
    [SerializeField] TMP_Text challengeText;   
    [Header("Tutorial window references")]
    [SerializeField] GameObject tutorialWindowEnglish;
    [SerializeField] GameObject tutorialWindowDutch;
    

    
    public void OnNotify(ButtonType value)
    {
        Debug.Log("Recieved message " + value);
        if (value == ButtonType.English)
        {
            languageSelectCanvas.SetActive(false);
            gamemodeSelectCanvas.SetActive(true);
            languageIsEnglish = true;
        }

        if (value == ButtonType.Dutch)
        {
            languageSelectCanvas.SetActive(false);
            gamemodeSelectCanvas.SetActive(true);
            languageIsDutch = true;
        }   
        //GetButtons();
        SetLanguage();

        if (value != ButtonType.Challenge)
        {
            if (languageIsDutch)
            {tutorialWindowDutch.SetActive(true);}
            else
            {tutorialWindowEnglish.SetActive(true);}
        }
    }

    /*/void GetButtons()
    {
        //finding the text areas of the gamemode select screen
        guidanceButton = GameObject.Find("GuidanceText");
        guidanceText = guidanceButton.GetComponent<TMP_Text>();
        
        practiceButton = GameObject.Find("PracticeText");
        practiceText = practiceButton.GetComponent<TMP_Text>();

        challengeButton = GameObject.Find("ChallengeText");
        challengeText = challengeButton.GetComponent<TMP_Text>();
    }*/
    void SetLanguage()
    {
        //if (languageIsDutch);
        if (languageIsDutch)
        {
            guidanceText.text = "Hulpmodus";
            practiceText.text = "Oefenmodus";
            challengeText.text = "Uitdagingsmodus";
        }
        else if (languageIsEnglish)
        {
            guidanceText.text = "Guidance mode";
            practiceText.text = "Practice mode";
            challengeText.text = "Challange mode";
        }
    }

    
    void OnEnable()
    {
        //Subscribes to the subjects list of observers
        languageSubject.AddObserver(this);
    }

    
    void OnDisable()
    {
        //Removes itself from the subjects list of observers
        languageSubject.RemoveObserver(this);        
    }
}
