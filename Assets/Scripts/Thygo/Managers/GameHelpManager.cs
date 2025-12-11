using UnityEngine;

public class GameHelpManager : Subject<HelpAmount>, IAmObserver<ButtonType>
{
    //change names to what they actually are
    //references to the thing that provides some form of help
    [SerializeField] GameObject HelpField1;
    [SerializeField] GameObject HelpField2;
    [SerializeField] GameObject HelpField3;
    [SerializeField] GameObject HelpField4;
    [SerializeField] GameObject HelpField5;
    [SerializeField] GameObject HelpField6;
    [SerializeField] GameObject HelpField7;
    [SerializeField] GameObject HelpField8;
    [SerializeField] GameObject HelpField9;
}
