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
    GameObject guidanceButton;
    GameObject practiceButton;
    GameObject advancedButton;
    TMP_Text guidanceText;
    TMP_Text practiceText;    
    TMP_Text advancedText;    
    

    void Awake()
    {
        guidanceButton = GameObject.Find("GuidanceText");
        guidanceText = guidanceButton.GetComponent<TMP_Text>();
        
        practiceButton = GameObject.Find("GuidanceText");
        practiceText = practiceButton.GetComponent<TMP_Text>();

        advancedButton = GameObject.Find("GuidanceText");
        advancedText = advancedButton.GetComponent<TMP_Text>();
    }
    
    public void OnNotify(ButtonType value)
    {
        Debug.Log("Recieved message " + value);
        if (value == ButtonType.English)
        {
            languageIsEnglish = true;
        }

        if (value == ButtonType.Dutch)
        {
            languageIsDutch = true;
            guidanceText.text = "languageIsDutch";
        }   
    }

    void SetLanguage()
    {
        //if (languageIsDutch);
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
