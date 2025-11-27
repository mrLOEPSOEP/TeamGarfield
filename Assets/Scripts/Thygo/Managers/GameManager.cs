using UnityEngine;

public class GameManager : MonoBehaviour, IAmObserver<ButtonType>
{
    //Variables
    bool languageIsDutch;
    bool languageIsEnglish;
    int gameMode;
    public void OnNotify(ButtonType type)
    {
        //Determine and store language
        if (type == ButtonType.Dutch)
            languageIsDutch = true;
        else if (type == ButtonType.English)
            languageIsEnglish = true;

        //Determine and select gamemode the number is correspondant to the amount of guidance 0 = none and 2 = full
        if (type == ButtonType.Guidance)
            gameMode = 2;
        else if (type == ButtonType.Practice)
            gameMode = 1;
        else if (type == ButtonType.Challenge)
            gameMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
