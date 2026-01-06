using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameModeSelect : Subject<ButtonType>
{
    [SerializeField] GameObject menuManagerObject;
    [SerializeField] GameObject TeleportPosition; //can be removed when the locker room clothing game is finished
    [SerializeField] GameObject player; //can be removed when the locker room clothing game is finished
    
    
    //Functionality of the buttons
    public void OnGuidanceModeSelected()
    {
        NotifyObservers(ButtonType.Guidance);
        gameObject.SetActive(false);
        //TeleportToDrillingRoom();
    }   

    public void OnPracticeModeSelected()
    {
        NotifyObservers(ButtonType.Practice);
        gameObject.SetActive(false);
        //TeleportToDrillingRoom();
    } 

    public void OnChallengeModeSelected()
    {
        NotifyObservers(ButtonType.Challenge);
        gameObject.SetActive(false);
        //TeleportToDrillingRoom();
    }
    //To teleport the player to the drilling room can be removed once locker room clothing game is finished
    void TeleportToDrillingRoom()
    {
        player.transform.position = TeleportPosition.transform.position;
    }
}
