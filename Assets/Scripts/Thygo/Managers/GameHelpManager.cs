using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHelpManager : MonoBehaviour, IAmObserver<ButtonType>
{
    //change names to what they actually are
    //references to the thing that provides some form of help
    #region Serializables
    [Header("References to the textbox in UI")]
    [SerializeField] Text startMachineUI;
    [SerializeField] Text emergenyStopUI;
    [SerializeField] Text drillSpeedKnobUI;
    [SerializeField] Text materialClampUI;
    [SerializeField] Text shieldUI;
    [SerializeField] Text drillBitUI;
    [SerializeField] Text stopMachineUI;
    [SerializeField] Text heightCrankUI;
    [SerializeField] Text leftRightCrankUI;
    [SerializeField] Text forwardBackCrankUI;

    [Header("UI text English")]
    [SerializeField] string startMachineTextEnglish;
    [SerializeField] string emergenyStopTextEnglish;
    [SerializeField] string drillSpeedKnobTextEnglish;
    [SerializeField] string materialClampTextEnglish;
    [SerializeField] string shieldTextEnglish;
    [SerializeField] string drillBitTextEnglish;
    [SerializeField] string stopMachineTextEnglish;
    [SerializeField] string heightCrankTextEnglish;
    [SerializeField] string leftRightCranktextEnglish;
    [SerializeField] string forwardBackCrankTextEnglish;
    
    [Header("UI text Dutch")]
    [SerializeField] string startMachineTextDutch;
    [SerializeField] string emergenyStopTextDutch;
    [SerializeField] string drillSpeedKnobTextDutch;
    [SerializeField] string materialClampTextDutch;
    [SerializeField] string shieldTextDutch;
    [SerializeField] string drillBitTextDutch;
    [SerializeField] string stopMachineTextDutch;
    [SerializeField] string heightCrankTextDutch;
    [SerializeField] string leftRightCranktextDutch;
    [SerializeField] string forwardBackCrankTextDutch;
    #endregion


    //Start for testing stuff
    void Start()
    {
        SetUITextEnglish();
    }

    
    //on notification received determine the mode and the language and set the language accordingly
    public void OnNotify(ButtonType buttonType)
    {
        //Check if guidancemode has been selected
        SetGuidanceMode(buttonType);
    }

    void SetGuidanceMode(ButtonType buttonType)
    {
        if (buttonType == ButtonType.Guidance);
        {
            //Check and set the language
            if (buttonType == ButtonType.English)
            {
                SetUITextEnglish();
            }
            else if (buttonType == ButtonType.Dutch)
            {
                SetUITextDutch();
            }
        }
    }


    //Setting all tooltips to English
    void SetUITextEnglish()
    {
        startMachineUI.text     = startMachineTextEnglish;
        emergenyStopUI.text     = emergenyStopTextEnglish;
        drillSpeedKnobUI.text   = drillBitTextEnglish;
        materialClampUI.text    = materialClampTextEnglish;
        shieldUI.text           = shieldTextEnglish;
        drillBitUI.text         = drillBitTextEnglish;
        stopMachineUI.text      = startMachineTextEnglish;
        heightCrankUI.text      = heightCrankTextEnglish;
        leftRightCrankUI.text   = leftRightCranktextEnglish;
        forwardBackCrankUI.text = forwardBackCrankTextEnglish;
    }

    //Setting all text to Dutch for those who want to use that language
    void SetUITextDutch()
    {
        startMachineUI.text     = startMachineTextDutch;
        emergenyStopUI.text     = emergenyStopTextDutch;
        drillSpeedKnobUI.text   = drillBitTextDutch;
        materialClampUI.text    = materialClampTextDutch;
        shieldUI.text           = shieldTextDutch;
        drillBitUI.text         = drillBitTextDutch;
        stopMachineUI.text      = startMachineTextDutch;
        heightCrankUI.text      = heightCrankTextDutch;
        leftRightCrankUI.text   = leftRightCranktextDutch;
        forwardBackCrankUI.text = forwardBackCrankTextDutch;
    }


}
