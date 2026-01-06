using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHelpManager : MonoBehaviour, IAmObserver<ButtonType>
{
    //change names to what they actually are
    //references to the thing that provides some form of help
    #region Serializables
    [Header("References to the textbox in UI")]
    [SerializeField] GameObject startMachine;
    [SerializeField] GameObject emergenyStop;
    [SerializeField] GameObject drillSpeedKnob;
    [SerializeField] GameObject materialClamp;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject drillBit;
    [SerializeField] GameObject stopMachine;
    [SerializeField] GameObject heightCrank;
    [SerializeField] GameObject leftRightCrank;
    [SerializeField] GameObject forwardBackCrank;

    TextMeshProUGUI startMachineUI;
    TextMeshProUGUI emergenyStopUI;
    TextMeshProUGUI drillSpeedKnobUI;
    TextMeshProUGUI materialClampUI;
    TextMeshProUGUI shieldUI;
    TextMeshProUGUI drillBitUI;
    TextMeshProUGUI stopMachineUI;
    TextMeshProUGUI heightCrankUI;
    TextMeshProUGUI leftRightCrankUI;
    TextMeshProUGUI forwardBackCrankUI;

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


    //Get the corresponding text box in the lazy tooltip and set it to its variable.
    void Start()
    {
        if (startMachine != null)startMachineUI =             startMachine.GetComponentInChildren<TextMeshProUGUI>();
        if (emergenyStop != null)emergenyStopUI  =            emergenyStop.GetComponentInChildren<TextMeshProUGUI>();
        if (drillSpeedKnob != null)drillSpeedKnobUI =       drillSpeedKnob.GetComponentInChildren<TextMeshProUGUI>();
        if (materialClamp != null)materialClampUI =          materialClamp.GetComponentInChildren<TextMeshProUGUI>();
        if (shield != null)shieldUI =                               shield.GetComponentInChildren<TextMeshProUGUI>();
        if (drillBit != null)drillBitUI =                         drillBit.GetComponentInChildren<TextMeshProUGUI>();
        if (stopMachine != null)stopMachineUI =                stopMachine.GetComponentInChildren<TextMeshProUGUI>();
        if (heightCrank != null)heightCrankUI =                heightCrank.GetComponentInChildren<TextMeshProUGUI>();
        if (leftRightCrank != null)leftRightCrankUI =       leftRightCrank.GetComponentInChildren<TextMeshProUGUI>();
        if (forwardBackCrank != null)forwardBackCrankUI = forwardBackCrank.GetComponentInChildren<TextMeshProUGUI>();  
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
        if (buttonType == ButtonType.Guidance)
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
        if (startMachineUI != null)startMachineUI.text     = startMachineTextEnglish;
        if (emergenyStopUI != null)emergenyStopUI.text     = emergenyStopTextEnglish;
        if (drillSpeedKnobUI != null)drillSpeedKnobUI.text   = drillBitTextEnglish;
        if (materialClampUI != null)materialClampUI.text    = materialClampTextEnglish;
        if (shieldUI != null)shieldUI.text           = shieldTextEnglish;
        if (drillBitUI != null)drillBitUI.text         = drillBitTextEnglish;
        if (stopMachineUI != null)stopMachineUI.text      = startMachineTextEnglish;
        if (heightCrankUI != null)heightCrankUI.text      = heightCrankTextEnglish;
        if (leftRightCrankUI != null)leftRightCrankUI.text   = leftRightCranktextEnglish;
        if (forwardBackCrankUI != null)forwardBackCrankUI.text = forwardBackCrankTextEnglish;
    }

    //Setting all text to Dutch for those who want to use that language
    void SetUITextDutch()
    {
        if (startMachineUI != null)startMachineUI.text     = startMachineTextDutch;
        if (emergenyStopUI != null)emergenyStopUI.text     = emergenyStopTextDutch;
        if (drillSpeedKnobUI != null)drillSpeedKnobUI.text   = drillBitTextDutch;
        if (materialClampUI != null)materialClampUI.text    = materialClampTextDutch;
        if (shieldUI != null)shieldUI.text           = shieldTextDutch;
        if (drillBitUI != null)drillBitUI.text         = drillBitTextDutch;
        if (stopMachineUI != null)stopMachineUI.text      = startMachineTextDutch;
        if (heightCrankUI != null)heightCrankUI.text      = heightCrankTextDutch;
        if (leftRightCrankUI != null)leftRightCrankUI.text   = leftRightCranktextDutch;
        if (forwardBackCrankUI != null)forwardBackCrankUI.text = forwardBackCrankTextDutch;
    }


}
